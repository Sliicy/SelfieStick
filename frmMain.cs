using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Linq;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;

namespace SelfieStick
{
    public record TimestampEntry(TimeSpan Time, string EventName);
    public partial class frmMain : Form
    {

        #region Unchanged Code (Logging, Service Control, etc.)
        private bool _isRecording = false;
        private DateTime _recordingStartTime;
        private string? _outputFilePath;
        private readonly List<TimestampEntry> _timestampEntries = new();
        private enum LogLevel { INFO, WARN, ERROR, DEBUG }

        private GattServiceProvider? _serviceProvider;
        private GattLocalCharacteristic? _inputReportCharacteristic;
        private bool _isServiceRunning = false;
        private bool _isSendingCommand = false;

        private const byte VOL_UP_PAYLOAD = 0x01;
        private const byte VOL_DOWN_PAYLOAD = 0x02;
        private const byte PLAY_PAUSE_PAYLOAD = 0x04;

        private static readonly Guid HidServiceUuid = new("00001812-0000-1000-8000-00805f9b34fb");
        private static readonly Guid HidReportMapUuid = new("00002a4b-0000-1000-8000-00805f9b34fb");
        private static readonly Guid HidInformationUuid = new("00002a4a-0000-1000-8000-00805f9b34fb");
        private static readonly Guid HidControlPointUuid = new("00002a4c-0000-1000-8000-00805f9b34fb");
        private static readonly Guid InputReportUuid = new("00002a4d-0000-1000-8000-00805f9b34fb");
        private static readonly Guid GattDescriptorUuidReportReference = new("00002908-0000-1000-8000-00805f9b34fb");
        public frmMain()
        {
            InitializeComponent();
            Log("Application started.");
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            await StartService();
        }

        private void Log(string message, LogLevel level = LogLevel.INFO)
        {
            if (this.InvokeRequired) { this.Invoke(() => Log(message, level)); return; }
            string formattedMessage = $"{DateTime.Now:HH:mm:ss.fff} [{level}] {message}{Environment.NewLine}";
            logTextBox.AppendText(formattedMessage);
            logTextBox.ScrollToCaret();
        }
        private void ClearLogButton_Click(object sender, EventArgs e) => logTextBox.Clear();
        private void StartStopButton_Click(object sender, EventArgs e) { }

        #region Timestamping Logic (Unchanged)
        private async void StartStopRecordingButton_Click(object sender, EventArgs e)
        {
            _isRecording = !_isRecording;
            if (_isRecording)
            {
                await SendCommandAsync(PLAY_PAUSE_PAYLOAD, "Shutter/Play");

                // --- START RECORDING ---
                _recordingStartTime = DateTime.Now;
                startStopRecordingButton.Text = "Stop Recording";
                timestampsGroupBox.Enabled = true; // Enable timestamp buttons
                recordingTimer.Start();
                InitializeTimestampFile();
                AddTimestamp("Recording Started");
                Log("Recording session started.");
            }
            else
            {
                await SendCommandAsync(PLAY_PAUSE_PAYLOAD, "Shutter/Play");

                // --- STOP RECORDING ---
                recordingTimer.Stop();
                AddTimestamp("Recording Stopped");
                SaveTimestampsToFile(); // Final save
                startStopRecordingButton.Text = "Start Recording";
                timestampsGroupBox.Enabled = false; // Disable timestamp buttons
                Log("Recording session stopped. Final timestamps saved.");
            }
        }

        private void NewSectionButton_Click(object sender, EventArgs e) => AddTimestamp("New Section");
        private void CensorReminderButton_Click(object sender, EventArgs e) => AddTimestamp("Censor Reminder");

        private void AddTimestamp(string eventName)
        {
            if (!_isRecording) return;

            TimeSpan elapsedTime = DateTime.Now - _recordingStartTime;
            var entry = new TimestampEntry(elapsedTime, eventName);
            _timestampEntries.Add(entry);

            string formattedTime = elapsedTime.ToString(@"hh\:mm\:ss");
            timestampsTextBox.AppendText($"{formattedTime} {eventName}{Environment.NewLine}");

            SaveTimestampsToFile();
        }

        private void InitializeTimestampFile()
        {
            try
            {
                string videosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                string dateString = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                _outputFilePath = Path.Combine(videosPath, $"SelfieStick_Markers_{dateString}.xml");
                Log($"Timestamp file initialized at: {_outputFilePath}");
            }
            catch (Exception ex)
            {
                Log($"Could not determine Videos folder path: {ex.Message}", LogLevel.ERROR);
            }
        }

        private void SaveTimestampsToFile()
        {
            if (string.IsNullOrEmpty(_outputFilePath) || _timestampEntries.Count == 0) return;
            try
            {
                const int fps = 30;
                TimeSpan maxDuration = _timestampEntries.Count > 0 ? _timestampEntries.Max(e => e.Time) : TimeSpan.Zero;
                int totalFrames = (int)(maxDuration.TotalSeconds * fps) + (5 * fps);
                var xmeml = new XElement("xmeml", new XAttribute("version", "4"), new XElement("sequence", new XAttribute("id", "sequence-1"), new XElement("uuid", Guid.NewGuid().ToString().ToUpper()), new XElement("duration", totalFrames), new XElement("rate", new XElement("timebase", fps), new XElement("ntsc", "FALSE")), new XElement("name", Path.GetFileNameWithoutExtension(_outputFilePath)), new XElement("media", new XElement("video"), new XElement("audio")), new XElement("timecode", new XElement("rate", new XElement("timebase", fps), new XElement("ntsc", "FALSE")), new XElement("string", "00:00:00:00"), new XElement("frame", "0"), new XElement("displayformat", "NDF"))));
                XElement sequence = xmeml.Element("sequence");
                foreach (var entry in _timestampEntries)
                {
                    TimeSpan time = entry.Time;
                    int totalFramesAtTime = (int)(time.TotalSeconds * fps);
                    double fractionalSeconds = time.TotalSeconds - Math.Truncate(time.TotalSeconds);
                    int frame = (int)Math.Round(fractionalSeconds * fps);
                    string humanReadableTimecode = $"{time:hh\\:mm\\:ss}:{frame:D2} @ {fps}fps";
                    sequence.Add(new XElement("marker", new XElement("name", entry.EventName), new XElement("comment", humanReadableTimecode), new XElement("in", totalFramesAtTime), new XElement("out", "-1")));
                }
                var xmlDocument = new XDocument(new XDeclaration("1.0", "UTF-8", null), new XDocumentType("xmeml", null, null, null), xmeml);
                xmlDocument.Save(_outputFilePath);
                Log($"Saved {_timestampEntries.Count} timestamps to XML file.", LogLevel.DEBUG);
            }
            catch (Exception ex)
            {
                Log($"Failed to save XML file: {ex.Message}", LogLevel.ERROR);
            }
        }

        private void RecordingTimer_Tick(object sender, EventArgs e)
        {
            if (_isRecording)
            {
                TimeSpan elapsedTime = DateTime.Now - _recordingStartTime;
                recordingTimerLabel.Text = elapsedTime.ToString(@"hh\:mm\:ss");
            }
        }

        private void ClearTimestampsButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all timestamps for this session?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _timestampEntries.Clear();
                timestampsTextBox.Clear();
                if (!string.IsNullOrEmpty(_outputFilePath) && File.Exists(_outputFilePath))
                {
                    try
                    {
                        InitializeTimestampFile();
                        Log("Timestamps cleared from UI. A new session will write to the same file or a new one if the date changes.");
                    }
                    catch (Exception ex)
                    {
                        Log($"Error during timestamp clear: {ex.Message}", LogLevel.ERROR);
                    }
                }
                AddTimestamp("Timestamps Cleared");
            }
        }
        #endregion

        private async Task StartService()
        {
            Log("Attempting to start service...");
            statusLabel.Text = "Status: Initializing GATT service...";
            try
            {
                GattServiceProviderResult result = await GattServiceProvider.CreateAsync(HidServiceUuid);
                if (result.Error != BluetoothError.Success)
                {
                    Log($"Failed to create HID service: {result.Error}", LogLevel.ERROR);
                    MessageBox.Show($"Could not create HID service: {result.Error}. Try running as Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetUiToIdle();
                    return;
                }
                _serviceProvider = result.ServiceProvider;

                await CreateHidCharacteristics();

                var advParameters = new GattServiceProviderAdvertisingParameters { IsDiscoverable = true, IsConnectable = true };
                _serviceProvider.StartAdvertising(advParameters);

                Log("Advertising started. Service is running.");
                _isServiceRunning = true;
                statusLabel.Text = "Status: Advertising. Pair devices from phone(s) now...";
            }
            catch (Exception ex)
            {
                Log($"An exception occurred during service startup: {ex.Message}", LogLevel.ERROR);
                MessageBox.Show($"An error occurred: {ex.Message}\n\nPlease ensure your computer's Bluetooth is turned on.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetUiToIdle();
            }
        }

        private void StopService()
        {
            Log("Stopping service...");
            _serviceProvider?.StopAdvertising();
            _serviceProvider = null;
            _inputReportCharacteristic = null;
            Log("Service stopped and resources released.");
            ResetUiToIdle();
        }
        private void ResetUiToIdle()
        {
            _isServiceRunning = false;
            statusLabel.Text = "Status: Idle";
            remoteControlGroupBox.Enabled = false;
            connectedDevicesListBox.Items.Clear();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isRecording)
            {
                AddTimestamp("Recording Stopped (App Closed)");
                SaveTimestampsToFile();
            }
            StopService();
        }

        private void InputReportCharacteristic_SubscribedClientsChanged(GattLocalCharacteristic sender, object args)
        {
            Log("SubscribedClientsChanged event fired.", LogLevel.DEBUG);
            this.Invoke(UpdateConnectedDevicesList);
        }
        private void UpdateConnectedDevicesList()
        {
            if (!_isServiceRunning || _inputReportCharacteristic == null) return;

            var clients = _inputReportCharacteristic.SubscribedClients;
            int clientCount = clients.Count;
            Log($"Found {clientCount} subscribed client(s).");

            if (_isRecording && clientCount == 0)
            {
                Log("All devices disconnected during recording. Automatically stopping session.", LogLevel.WARN);
                StartStopRecordingButton_Click(null, EventArgs.Empty);
                return;
            }

            connectedDevicesListBox.Items.Clear();
            for (int i = 0; i < clientCount; i++)
            {
                connectedDevicesListBox.Items.Add($"Connected Device #{i + 1}");
            }

            bool clientsConnected = clientCount > 0;
            remoteControlGroupBox.Enabled = clientsConnected;
            startStopRecordingButton.Enabled = _isRecording || clientsConnected;

            Log(clientsConnected ? "Remote control panel ENABLED." : "Remote control panel DISABLED.");
            if (clientsConnected)
            {
                statusLabel.Text = $"Status: {clientCount} device(s) connected.";
            }
            else
            {
                statusLabel.Text = "Status: Advertising. Waiting for connections...";
            }
        }
        private async void ShutterButton_Click(object sender, EventArgs e) => await SendCommandAsync(PLAY_PAUSE_PAYLOAD, "Shutter/Play");
        private async void VolumeUpButton_Click(object sender, EventArgs e) => await SendCommandAsync(VOL_UP_PAYLOAD, "Volume Up");
        private async void VolumeDownButton_Click(object sender, EventArgs e) => await SendCommandAsync(VOL_DOWN_PAYLOAD, "Volume Down");
        #endregion


        //================================================================================
        // CORRECTED METHOD - SENDS HID-COMPLIANT PAYLOAD
        //================================================================================
        private async Task SendCommandAsync(byte commandIdentifier, string commandName)
        {
            if (commandIdentifier != VOL_UP_PAYLOAD)
            {
                Log($"Command '{commandName}' ignored as per requirements.", LogLevel.WARN);
                return;
            }

            if (_isSendingCommand || !_isServiceRunning || _inputReportCharacteristic == null || _inputReportCharacteristic.SubscribedClients.Count == 0)
            {
                return;
            }

            try
            {
                _isSendingCommand = true;
                remoteControlGroupBox.Enabled = false;

                // PAYLOADS THAT ARE COMPLIANT WITH THE NEW, STANDARD HID REPORT MAP
                // We send the 16-bit HID Usage ID for the pressed key.
                // 0x00E9 = Volume Increment (Volume Up)
                var pressPayload = new byte[] { 0xE9, 0x00 };

                // 0x0000 = No key pressed (Release)
                var releasePayload = new byte[] { 0x00, 0x00 };

                Log($"Sending Volume Up (0x00E9) PRESS notification...", LogLevel.DEBUG);
                await _inputReportCharacteristic.NotifyValueAsync(pressPayload.AsBuffer());

                await Task.Delay(50);

                Log($"Sending Volume Up (0x0000) RELEASE notification...", LogLevel.DEBUG);
                await _inputReportCharacteristic.NotifyValueAsync(releasePayload.AsBuffer());

                statusLabel.Text = $"Status: Sent 'Volume Up' to {_inputReportCharacteristic.SubscribedClients.Count} device(s).";
            }
            catch (Exception ex)
            {
                Log($"EXCEPTION in SendCommandAsync: {ex.Message}", LogLevel.ERROR);
            }
            finally
            {
                _isSendingCommand = false;
                if (_inputReportCharacteristic != null && _inputReportCharacteristic.SubscribedClients.Count > 0)
                {
                    remoteControlGroupBox.Enabled = true;
                }
            }
        }

        private async Task CreateHidCharacteristics()
        {
            if (_serviceProvider == null) return;
            Log("Creating HID characteristics...", LogLevel.DEBUG);

            var protectionLevel = GattProtectionLevel.EncryptionRequired;

            var reportMapParameters = new GattLocalCharacteristicParameters { CharacteristicProperties = GattCharacteristicProperties.Read, StaticValue = GetHidReportMap().AsBuffer(), ReadProtectionLevel = protectionLevel };
            var result = await _serviceProvider.Service.CreateCharacteristicAsync(HidReportMapUuid, reportMapParameters);
            if (result.Error != BluetoothError.Success) throw new Exception($"Create Report Map failed: {result.Error}");

            var infoParameters = new GattLocalCharacteristicParameters { CharacteristicProperties = GattCharacteristicProperties.Read, StaticValue = new byte[] { 0x11, 0x01, 0x00, 0x03 }.AsBuffer(), ReadProtectionLevel = protectionLevel };
            result = await _serviceProvider.Service.CreateCharacteristicAsync(HidInformationUuid, infoParameters);
            if (result.Error != BluetoothError.Success) throw new Exception($"Create HID Info failed: {result.Error}");

            var inputReportParameters = new GattLocalCharacteristicParameters { CharacteristicProperties = GattCharacteristicProperties.Read | GattCharacteristicProperties.Notify, ReadProtectionLevel = protectionLevel };
            var inputReportResult = await _serviceProvider.Service.CreateCharacteristicAsync(InputReportUuid, inputReportParameters);
            if (inputReportResult.Error != BluetoothError.Success) throw new Exception($"Create Input Report failed: {inputReportResult.Error}");

            _inputReportCharacteristic = inputReportResult.Characteristic;
            _inputReportCharacteristic.SubscribedClientsChanged += InputReportCharacteristic_SubscribedClientsChanged;

            var reportRefParams = new GattLocalDescriptorParameters { StaticValue = new byte[] { 0x01, 0x01 }.AsBuffer(), ReadProtectionLevel = protectionLevel };
            var descResult = await _inputReportCharacteristic.CreateDescriptorAsync(GattDescriptorUuidReportReference, reportRefParams);
            if (descResult.Error != BluetoothError.Success) throw new Exception($"Create Report Ref failed: {descResult.Error}");

            var controlPointParameters = new GattLocalCharacteristicParameters { CharacteristicProperties = GattCharacteristicProperties.WriteWithoutResponse, WriteProtectionLevel = protectionLevel };
            result = await _serviceProvider.Service.CreateCharacteristicAsync(HidControlPointUuid, controlPointParameters);
            if (result.Error != BluetoothError.Success) throw new Exception($"Create Control Point failed: {result.Error}");

            Log("All HID characteristics created successfully.");
        }

        //================================================================================
        // CORRECTED HID REPORT MAP - THIS IS THE MOST CRITICAL CHANGE
        //================================================================================
        private static byte[] GetHidReportMap()
        {
            // This HID Report Map tells the OS (iOS/Android) that we will be sending
            // a single 16-bit value representing the specific consumer control key that was pressed.
            // This is a standard and highly compatible way to implement media keys.
            return
            [
                0x05, 0x0C,       // Usage Page (Consumer)
                0x09, 0x01,       // Usage (Consumer Control)
                0xA1, 0x01,       // Collection (Application)
                0x85, 0x01,       //   Report ID (1)
                0x15, 0x01,       //   Logical Minimum (1)
                0x26, 0xFF, 0x03, //   Logical Maximum (1023)
                0x19, 0x01,       //   Usage Minimum (1)
                0x2A, 0xFF, 0x03, //   Usage Maximum (1023)
                0x75, 0x10,       //   Report Size (16) -> 2 bytes
                0x95, 0x01,       //   Report Count (1)
                0x81, 0x00,       //   Input (Data,Ary,Abs)
                0xC0              // End Collection
            ];
        }

        private void OpenTimelogsFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
        }
    }
}
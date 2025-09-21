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
        
        private bool _isRecording = false;
        private DateTime _recordingStartTime;
        private string? _outputFilePath;
        private readonly List<TimestampEntry> _timestampEntries = new();
        private enum LogLevel { INFO, WARN, ERROR, DEBUG }

        private GattServiceProvider? _serviceProvider;
        private GattLocalCharacteristic? _inputReportCharacteristic;
        private bool _isServiceRunning = false;
        private bool _isSendingCommand = false;

        private const byte CMD_ID_VOL_UP = 1;
        private const byte CMD_ID_VOL_DOWN = 2;
        private const byte CMD_ID_PLAY_PAUSE = 3;
        private const byte CMD_ID_NEXT_TRACK = 4; // --- ADDED ---
        private const byte CMD_ID_PREV_TRACK = 5; // --- ADDED ---

        private static readonly Guid HidServiceUuid = new("00001812-0000-1000-8000-00805f9b34fb");
        private static readonly Guid HidReportMapUuid = new("00002a4b-0000-1000-8000-00805f9b34fb");
        private static readonly Guid HidInformationUuid = new("00002a4a-0000-1000-8000-00805f9b34fb");
        private static readonly Guid HidControlPointUuid = new("00002a4c-0000-1000-8000-00805f9b34fb");
        private static readonly Guid InputReportUuid = new("00002a4d-0000-1000-8000-00805f9b34fb");
        private static readonly Guid GattDescriptorUuidReportReference = new("00002908-0000-1000-8000-00805f9b34fb");
        public frmMain()
        {
            InitializeComponent();
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            await StartService();
        }
        
        private async void StartStopRecordingButton_Click(object sender, EventArgs e)
        {
            _isRecording = !_isRecording;
            if (_isRecording)
            {
                await SendCommandAsync(CMD_ID_VOL_UP, "Start Recording Trigger");
                _recordingStartTime = DateTime.Now;
                startStopRecordingButton.Text = "Stop Recording";
                timestampsGroupBox.Enabled = true;
                recordingTimer.Start();
                InitializeTimestampFile();
                AddTimestamp("Recording Started");
            }
            else
            {
                await SendCommandAsync(CMD_ID_VOL_UP, "Stop Recording Trigger");
                recordingTimer.Stop();
                AddTimestamp("Recording Stopped");
                SaveTimestampsToFile();
                startStopRecordingButton.Text = "Start Recording";
                timestampsGroupBox.Enabled = false;
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
            }
            catch (Exception ex)
            {
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
            }
            catch (Exception ex)
            {
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
                        
                    }
                    catch (Exception ex)
                    {
                    }
                }
                AddTimestamp("Timestamps Cleared");
            }
        }

        private async Task StartService()
        {
            statusLabel.Text = "Status: Initializing GATT service...";
            try
            {
                GattServiceProviderResult result = await GattServiceProvider.CreateAsync(HidServiceUuid);
                if (result.Error != BluetoothError.Success)
                {
                    MessageBox.Show($"Could not create HID service: {result.Error}. Try running as Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetUiToIdle();
                    return;
                }
                _serviceProvider = result.ServiceProvider;
                await CreateHidCharacteristics();
                var advParameters = new GattServiceProviderAdvertisingParameters { IsDiscoverable = true, IsConnectable = true };
                _serviceProvider.StartAdvertising(advParameters);
                _isServiceRunning = true;
                statusLabel.Text = "Status: Advertising. Pair devices from phone(s) now...";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\nPlease ensure your computer's Bluetooth is turned on.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetUiToIdle();
            }
        }

        private void StopService()
        {
            _serviceProvider?.StopAdvertising();
            _serviceProvider = null;
            _inputReportCharacteristic = null;
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
            this.Invoke(UpdateConnectedDevicesList);
        }
        private void UpdateConnectedDevicesList()
        {
            if (!_isServiceRunning || _inputReportCharacteristic == null) return;
            var clients = _inputReportCharacteristic.SubscribedClients;
            int clientCount = clients.Count;
            if (_isRecording && clientCount == 0)
            {
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
            if (clientsConnected)
            {
                statusLabel.Text = $"Status: {clientCount} device(s) connected.";
            }
            else
            {
                statusLabel.Text = "Status: Advertising. Waiting for connections...";
            }
        }
        

        // --- NEW AND UPDATED Event Handlers ---
        private async void VolumeUpButton_Click(object sender, EventArgs e) => await SendCommandAsync(CMD_ID_VOL_UP, "Volume Up");
        private async void volumeDownButton_Click(object sender, EventArgs e) => await SendCommandAsync(CMD_ID_VOL_DOWN, "Volume Down");
        private async void playPauseButton_Click(object sender, EventArgs e) => await SendCommandAsync(CMD_ID_PLAY_PAUSE, "Play/Pause");
        private async void nextButton_Click(object sender, EventArgs e) => await SendCommandAsync(CMD_ID_NEXT_TRACK, "Next Track");
        private async void previousButton_Click(object sender, EventArgs e) => await SendCommandAsync(CMD_ID_PREV_TRACK, "Previous Track");
        // --- shutterButton_Click was REMOVED ---

        private async Task SendCommandAsync(byte commandIdentifier, string commandName)
        {
            if (_isSendingCommand || !_isServiceRunning || _inputReportCharacteristic == null || _inputReportCharacteristic.SubscribedClients.Count == 0)
            {
                return;
            }

            try
            {
                _isSendingCommand = true;
                remoteControlGroupBox.Enabled = false;

                ushort usageId = 0;
                switch (commandIdentifier)
                {
                    case CMD_ID_VOL_UP:
                        usageId = 0x00E9; // Volume Increment
                        break;
                    case CMD_ID_VOL_DOWN:
                        usageId = 0x00EA; // Volume Decrement
                        break;
                    case CMD_ID_PLAY_PAUSE:
                        usageId = 0x00CD; // Play/Pause
                        break;
                    case CMD_ID_NEXT_TRACK:
                        usageId = 0x00B5; // Scan Next Track
                        break;
                    case CMD_ID_PREV_TRACK:
                        usageId = 0x00B6; // Scan Previous Track
                        break;
                    default:
                        return;
                }

                var pressPayload = BitConverter.GetBytes(usageId);
                var releasePayload = new byte[] { 0x00, 0x00 };

                await _inputReportCharacteristic.NotifyValueAsync(pressPayload.AsBuffer());

                await Task.Delay(50);

                await _inputReportCharacteristic.NotifyValueAsync(releasePayload.AsBuffer());

                statusLabel.Text = $"Status: Sent '{commandName}' to {_inputReportCharacteristic.SubscribedClients.Count} device(s).";
            }
            catch (Exception ex)
            {
                
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
        }

        private static byte[] GetHidReportMap()
        {
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
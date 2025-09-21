namespace SelfieStick
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            statusLabel = new Label();
            tabControl = new TabControl();
            timestampsTab = new TabPage();
            timestampsGroupBox = new GroupBox();
            clearTimestampsButton = new Button();
            censorReminderButton = new Button();
            newSectionButton = new Button();
            timestampsTextBox = new TextBox();
            remoteTab = new TabPage();
            grpConnectedDevices = new GroupBox();
            connectedDevicesListBox = new ListBox();
            remoteControlGroupBox = new GroupBox();
            remoteButtonsFlowLayoutPanel = new FlowLayoutPanel();
            volumeUpButton = new Button();
            volumeDownButton = new Button();
            playPauseButton = new Button();
            nextButton = new Button();
            previousButton = new Button();
            powerButton = new Button();
            powerLongPressButton = new Button();
            sleepButton = new Button();
            wakeButton = new Button();
            backButton = new Button();
            homeButton = new Button();
            menuButton = new Button();
            googleButton = new Button();
            brightnessUpButton = new Button();
            brightnessDownButton = new Button();
            fastForwardButton = new Button();
            rewindButton = new Button();
            stopButton = new Button();
            muteButton = new Button();
            calculatorButton = new Button();
            browserButton = new Button();
            calendarButton = new Button();
            scrollUpButton = new Button();
            scrollDownButton = new Button();
            cutButton = new Button();
            copyButton = new Button();
            pasteButton = new Button();
            selectButton = new Button();
            menuUpButton = new Button();
            menuDownButton = new Button();
            menuLeftButton = new Button();
            menuRightButton = new Button();
            menuEscapeButton = new Button();
            recordingGroupBox = new GroupBox();
            recordingTimerLabel = new Label();
            openTimelogsFolderButton = new Button();
            startStopRecordingButton = new Button();
            recordingTimer = new System.Windows.Forms.Timer(components);
            tabControl.SuspendLayout();
            timestampsTab.SuspendLayout();
            timestampsGroupBox.SuspendLayout();
            remoteTab.SuspendLayout();
            grpConnectedDevices.SuspendLayout();
            remoteControlGroupBox.SuspendLayout();
            remoteButtonsFlowLayoutPanel.SuspendLayout();
            recordingGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusLabel.BorderStyle = BorderStyle.Fixed3D;
            statusLabel.Location = new Point(0, 448);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(806, 27);
            statusLabel.TabIndex = 19;
            statusLabel.Text = "Status: Idle";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(timestampsTab);
            tabControl.Controls.Add(remoteTab);
            tabControl.Location = new Point(12, 65);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(782, 371);
            tabControl.TabIndex = 4;
            // 
            // timestampsTab
            // 
            timestampsTab.Controls.Add(timestampsGroupBox);
            timestampsTab.Controls.Add(timestampsTextBox);
            timestampsTab.Location = new Point(4, 29);
            timestampsTab.Name = "timestampsTab";
            timestampsTab.Padding = new Padding(3);
            timestampsTab.Size = new Size(774, 338);
            timestampsTab.TabIndex = 0;
            timestampsTab.Text = "Video Timestamps";
            timestampsTab.UseVisualStyleBackColor = true;
            // 
            // timestampsGroupBox
            // 
            timestampsGroupBox.Controls.Add(clearTimestampsButton);
            timestampsGroupBox.Controls.Add(censorReminderButton);
            timestampsGroupBox.Controls.Add(newSectionButton);
            timestampsGroupBox.Dock = DockStyle.Fill;
            timestampsGroupBox.Enabled = false;
            timestampsGroupBox.Location = new Point(3, 3);
            timestampsGroupBox.Name = "timestampsGroupBox";
            timestampsGroupBox.Size = new Size(488, 332);
            timestampsGroupBox.TabIndex = 5;
            timestampsGroupBox.TabStop = false;
            timestampsGroupBox.Text = "Timestamp Actions";
            // 
            // clearTimestampsButton
            // 
            clearTimestampsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clearTimestampsButton.Location = new Point(6, 289);
            clearTimestampsButton.Name = "clearTimestampsButton";
            clearTimestampsButton.Size = new Size(476, 37);
            clearTimestampsButton.TabIndex = 8;
            clearTimestampsButton.Text = "C&lear Timestamps";
            clearTimestampsButton.UseVisualStyleBackColor = true;
            clearTimestampsButton.Click += ClearTimestampsButton_Click;
            // 
            // censorReminderButton
            // 
            censorReminderButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            censorReminderButton.Location = new Point(6, 75);
            censorReminderButton.Name = "censorReminderButton";
            censorReminderButton.Size = new Size(476, 37);
            censorReminderButton.TabIndex = 7;
            censorReminderButton.Text = "&Censor Reminder";
            censorReminderButton.UseVisualStyleBackColor = true;
            censorReminderButton.Click += CensorReminderButton_Click;
            // 
            // newSectionButton
            // 
            newSectionButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newSectionButton.Location = new Point(6, 26);
            newSectionButton.Name = "newSectionButton";
            newSectionButton.Size = new Size(476, 37);
            newSectionButton.TabIndex = 6;
            newSectionButton.Text = "&New Section";
            newSectionButton.UseVisualStyleBackColor = true;
            newSectionButton.Click += NewSectionButton_Click;
            // 
            // timestampsTextBox
            // 
            timestampsTextBox.Dock = DockStyle.Right;
            timestampsTextBox.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timestampsTextBox.Location = new Point(491, 3);
            timestampsTextBox.Multiline = true;
            timestampsTextBox.Name = "timestampsTextBox";
            timestampsTextBox.ReadOnly = true;
            timestampsTextBox.ScrollBars = ScrollBars.Vertical;
            timestampsTextBox.Size = new Size(280, 332);
            timestampsTextBox.TabIndex = 9;
            // 
            // remoteTab
            // 
            remoteTab.Controls.Add(grpConnectedDevices);
            remoteTab.Controls.Add(remoteControlGroupBox);
            remoteTab.Location = new Point(4, 29);
            remoteTab.Name = "remoteTab";
            remoteTab.Padding = new Padding(3);
            remoteTab.Size = new Size(774, 338);
            remoteTab.TabIndex = 1;
            remoteTab.Text = "Remote Control & Debug";
            remoteTab.UseVisualStyleBackColor = true;
            // 
            // grpConnectedDevices
            // 
            grpConnectedDevices.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpConnectedDevices.Controls.Add(connectedDevicesListBox);
            grpConnectedDevices.Location = new Point(6, 241);
            grpConnectedDevices.Name = "grpConnectedDevices";
            grpConnectedDevices.Size = new Size(762, 91);
            grpConnectedDevices.TabIndex = 16;
            grpConnectedDevices.TabStop = false;
            grpConnectedDevices.Text = "Connected Devices";
            // 
            // connectedDevicesListBox
            // 
            connectedDevicesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            connectedDevicesListBox.FormattingEnabled = true;
            connectedDevicesListBox.Location = new Point(6, 21);
            connectedDevicesListBox.Name = "connectedDevicesListBox";
            connectedDevicesListBox.Size = new Size(750, 64);
            connectedDevicesListBox.TabIndex = 15;
            // 
            // remoteControlGroupBox
            // 
            remoteControlGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            remoteControlGroupBox.Controls.Add(remoteButtonsFlowLayoutPanel);
            remoteControlGroupBox.Enabled = false;
            remoteControlGroupBox.Location = new Point(3, 3);
            remoteControlGroupBox.Name = "remoteControlGroupBox";
            remoteControlGroupBox.Size = new Size(768, 232);
            remoteControlGroupBox.TabIndex = 10;
            remoteControlGroupBox.TabStop = false;
            remoteControlGroupBox.Text = "Phone Remote Control";
            // 
            // remoteButtonsFlowLayoutPanel
            // 
            remoteButtonsFlowLayoutPanel.AutoScroll = true;
            remoteButtonsFlowLayoutPanel.Controls.Add(volumeUpButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(volumeDownButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(playPauseButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(nextButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(previousButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(powerButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(powerLongPressButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(sleepButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(wakeButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(backButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(homeButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(menuButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(googleButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(brightnessUpButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(brightnessDownButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(fastForwardButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(rewindButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(stopButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(muteButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(calculatorButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(browserButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(calendarButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(scrollUpButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(scrollDownButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(cutButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(copyButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(pasteButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(selectButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(menuUpButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(menuDownButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(menuLeftButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(menuRightButton);
            remoteButtonsFlowLayoutPanel.Controls.Add(menuEscapeButton);
            remoteButtonsFlowLayoutPanel.Dock = DockStyle.Fill;
            remoteButtonsFlowLayoutPanel.Location = new Point(3, 23);
            remoteButtonsFlowLayoutPanel.Name = "remoteButtonsFlowLayoutPanel";
            remoteButtonsFlowLayoutPanel.Size = new Size(762, 206);
            remoteButtonsFlowLayoutPanel.TabIndex = 0;
            // 
            // volumeUpButton
            // 
            volumeUpButton.Location = new Point(3, 3);
            volumeUpButton.Name = "volumeUpButton";
            volumeUpButton.Size = new Size(110, 29);
            volumeUpButton.TabIndex = 11;
            volumeUpButton.Text = "Volume &Up";
            volumeUpButton.UseVisualStyleBackColor = true;
            volumeUpButton.Click += VolumeUpButton_Click;
            // 
            // volumeDownButton
            // 
            volumeDownButton.Location = new Point(119, 3);
            volumeDownButton.Name = "volumeDownButton";
            volumeDownButton.Size = new Size(110, 29);
            volumeDownButton.TabIndex = 12;
            volumeDownButton.Text = "Volume &Down";
            volumeDownButton.UseVisualStyleBackColor = true;
            volumeDownButton.Click += volumeDownButton_Click;
            // 
            // playPauseButton
            // 
            playPauseButton.Location = new Point(235, 3);
            playPauseButton.Name = "playPauseButton";
            playPauseButton.Size = new Size(110, 29);
            playPauseButton.TabIndex = 15;
            playPauseButton.Text = "P&lay/Pause";
            playPauseButton.UseVisualStyleBackColor = true;
            playPauseButton.Click += playPauseButton_Click;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(351, 3);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(110, 29);
            nextButton.TabIndex = 13;
            nextButton.Text = "&Next Track";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // previousButton
            // 
            previousButton.Location = new Point(467, 3);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(110, 29);
            previousButton.TabIndex = 14;
            previousButton.Text = "P&revious Track";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += previousButton_Click;
            // 
            // powerButton
            // 
            powerButton.Location = new Point(583, 3);
            powerButton.Name = "powerButton";
            powerButton.Size = new Size(110, 29);
            powerButton.TabIndex = 16;
            powerButton.Text = "Power";
            powerButton.UseVisualStyleBackColor = true;
            powerButton.Click += powerButton_Click;
            // 
            // powerLongPressButton
            // 
            powerLongPressButton.Location = new Point(3, 38);
            powerLongPressButton.Name = "powerLongPressButton";
            powerLongPressButton.Size = new Size(110, 29);
            powerLongPressButton.TabIndex = 17;
            powerLongPressButton.Text = "Power (Long)";
            powerLongPressButton.UseVisualStyleBackColor = true;
            powerLongPressButton.Click += powerLongPressButton_Click;
            // 
            // sleepButton
            // 
            sleepButton.Location = new Point(119, 38);
            sleepButton.Name = "sleepButton";
            sleepButton.Size = new Size(110, 29);
            sleepButton.TabIndex = 18;
            sleepButton.Text = "Sleep";
            sleepButton.UseVisualStyleBackColor = true;
            sleepButton.Click += sleepButton_Click;
            // 
            // wakeButton
            // 
            wakeButton.Location = new Point(235, 38);
            wakeButton.Name = "wakeButton";
            wakeButton.Size = new Size(110, 29);
            wakeButton.TabIndex = 19;
            wakeButton.Text = "Wake";
            wakeButton.UseVisualStyleBackColor = true;
            wakeButton.Click += wakeButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(351, 38);
            backButton.Name = "backButton";
            backButton.Size = new Size(110, 29);
            backButton.TabIndex = 20;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // homeButton
            // 
            homeButton.Location = new Point(467, 38);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(110, 29);
            homeButton.TabIndex = 21;
            homeButton.Text = "Home";
            homeButton.UseVisualStyleBackColor = true;
            homeButton.Click += homeButton_Click;
            // 
            // menuButton
            // 
            menuButton.Location = new Point(583, 38);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(110, 29);
            menuButton.TabIndex = 22;
            menuButton.Text = "Menu";
            menuButton.UseVisualStyleBackColor = true;
            menuButton.Click += menuButton_Click;
            // 
            // googleButton
            // 
            googleButton.Location = new Point(3, 73);
            googleButton.Name = "googleButton";
            googleButton.Size = new Size(110, 29);
            googleButton.TabIndex = 23;
            googleButton.Text = "Google/Siri";
            googleButton.UseVisualStyleBackColor = true;
            googleButton.Click += googleButton_Click;
            // 
            // brightnessUpButton
            // 
            brightnessUpButton.Location = new Point(119, 73);
            brightnessUpButton.Name = "brightnessUpButton";
            brightnessUpButton.Size = new Size(110, 29);
            brightnessUpButton.TabIndex = 24;
            brightnessUpButton.Text = "Bright ↑";
            brightnessUpButton.UseVisualStyleBackColor = true;
            brightnessUpButton.Click += brightnessUpButton_Click;
            // 
            // brightnessDownButton
            // 
            brightnessDownButton.Location = new Point(235, 73);
            brightnessDownButton.Name = "brightnessDownButton";
            brightnessDownButton.Size = new Size(110, 29);
            brightnessDownButton.TabIndex = 25;
            brightnessDownButton.Text = "Bright ↓";
            brightnessDownButton.UseVisualStyleBackColor = true;
            brightnessDownButton.Click += brightnessDownButton_Click;
            // 
            // fastForwardButton
            // 
            fastForwardButton.Location = new Point(351, 73);
            fastForwardButton.Name = "fastForwardButton";
            fastForwardButton.Size = new Size(110, 29);
            fastForwardButton.TabIndex = 26;
            fastForwardButton.Text = "Fast Forward";
            fastForwardButton.UseVisualStyleBackColor = true;
            fastForwardButton.Click += fastForwardButton_Click;
            // 
            // rewindButton
            // 
            rewindButton.Location = new Point(467, 73);
            rewindButton.Name = "rewindButton";
            rewindButton.Size = new Size(110, 29);
            rewindButton.TabIndex = 27;
            rewindButton.Text = "Rewind";
            rewindButton.UseVisualStyleBackColor = true;
            rewindButton.Click += rewindButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(583, 73);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(110, 29);
            stopButton.TabIndex = 28;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // muteButton
            // 
            muteButton.Location = new Point(3, 108);
            muteButton.Name = "muteButton";
            muteButton.Size = new Size(110, 29);
            muteButton.TabIndex = 29;
            muteButton.Text = "Mute";
            muteButton.UseVisualStyleBackColor = true;
            muteButton.Click += muteButton_Click;
            // 
            // calculatorButton
            // 
            calculatorButton.Location = new Point(119, 108);
            calculatorButton.Name = "calculatorButton";
            calculatorButton.Size = new Size(110, 29);
            calculatorButton.TabIndex = 30;
            calculatorButton.Text = "Calculator";
            calculatorButton.UseVisualStyleBackColor = true;
            calculatorButton.Click += calculatorButton_Click;
            // 
            // browserButton
            // 
            browserButton.Location = new Point(235, 108);
            browserButton.Name = "browserButton";
            browserButton.Size = new Size(110, 29);
            browserButton.TabIndex = 31;
            browserButton.Text = "Browser";
            browserButton.UseVisualStyleBackColor = true;
            browserButton.Click += browserButton_Click;
            // 
            // calendarButton
            // 
            calendarButton.Location = new Point(351, 108);
            calendarButton.Name = "calendarButton";
            calendarButton.Size = new Size(110, 29);
            calendarButton.TabIndex = 32;
            calendarButton.Text = "Calendar";
            calendarButton.UseVisualStyleBackColor = true;
            calendarButton.Click += calendarButton_Click;
            // 
            // scrollUpButton
            // 
            scrollUpButton.Location = new Point(467, 108);
            scrollUpButton.Name = "scrollUpButton";
            scrollUpButton.Size = new Size(110, 29);
            scrollUpButton.TabIndex = 33;
            scrollUpButton.Text = "Scroll Up";
            scrollUpButton.UseVisualStyleBackColor = true;
            scrollUpButton.Click += scrollUpButton_Click;
            // 
            // scrollDownButton
            // 
            scrollDownButton.Location = new Point(583, 108);
            scrollDownButton.Name = "scrollDownButton";
            scrollDownButton.Size = new Size(110, 29);
            scrollDownButton.TabIndex = 34;
            scrollDownButton.Text = "Scroll Down";
            scrollDownButton.UseVisualStyleBackColor = true;
            scrollDownButton.Click += scrollDownButton_Click;
            // 
            // cutButton
            // 
            cutButton.Location = new Point(3, 143);
            cutButton.Name = "cutButton";
            cutButton.Size = new Size(110, 29);
            cutButton.TabIndex = 35;
            cutButton.Text = "Cut";
            cutButton.UseVisualStyleBackColor = true;
            cutButton.Click += cutButton_Click;
            // 
            // copyButton
            // 
            copyButton.Location = new Point(119, 143);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(110, 29);
            copyButton.TabIndex = 36;
            copyButton.Text = "Copy";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // pasteButton
            // 
            pasteButton.Location = new Point(235, 143);
            pasteButton.Name = "pasteButton";
            pasteButton.Size = new Size(110, 29);
            pasteButton.TabIndex = 37;
            pasteButton.Text = "Paste";
            pasteButton.UseVisualStyleBackColor = true;
            pasteButton.Click += pasteButton_Click;
            // 
            // selectButton
            // 
            selectButton.Location = new Point(351, 143);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(110, 29);
            selectButton.TabIndex = 38;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // menuUpButton
            // 
            menuUpButton.Location = new Point(467, 143);
            menuUpButton.Name = "menuUpButton";
            menuUpButton.Size = new Size(110, 29);
            menuUpButton.TabIndex = 39;
            menuUpButton.Text = "Menu Up";
            menuUpButton.UseVisualStyleBackColor = true;
            menuUpButton.Click += menuUpButton_Click;
            // 
            // menuDownButton
            // 
            menuDownButton.Location = new Point(583, 143);
            menuDownButton.Name = "menuDownButton";
            menuDownButton.Size = new Size(110, 29);
            menuDownButton.TabIndex = 40;
            menuDownButton.Text = "Menu Down";
            menuDownButton.UseVisualStyleBackColor = true;
            menuDownButton.Click += menuDownButton_Click;
            // 
            // menuLeftButton
            // 
            menuLeftButton.Location = new Point(3, 178);
            menuLeftButton.Name = "menuLeftButton";
            menuLeftButton.Size = new Size(110, 29);
            menuLeftButton.TabIndex = 41;
            menuLeftButton.Text = "Menu Left";
            menuLeftButton.UseVisualStyleBackColor = true;
            menuLeftButton.Click += menuLeftButton_Click;
            // 
            // menuRightButton
            // 
            menuRightButton.Location = new Point(119, 178);
            menuRightButton.Name = "menuRightButton";
            menuRightButton.Size = new Size(110, 29);
            menuRightButton.TabIndex = 42;
            menuRightButton.Text = "Menu Right";
            menuRightButton.UseVisualStyleBackColor = true;
            menuRightButton.Click += menuRightButton_Click;
            // 
            // menuEscapeButton
            // 
            menuEscapeButton.Location = new Point(235, 178);
            menuEscapeButton.Name = "menuEscapeButton";
            menuEscapeButton.Size = new Size(110, 29);
            menuEscapeButton.TabIndex = 43;
            menuEscapeButton.Text = "Menu Esc";
            menuEscapeButton.UseVisualStyleBackColor = true;
            menuEscapeButton.Click += menuEscapeButton_Click;
            // 
            // recordingGroupBox
            // 
            recordingGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            recordingGroupBox.Controls.Add(recordingTimerLabel);
            recordingGroupBox.Controls.Add(openTimelogsFolderButton);
            recordingGroupBox.Controls.Add(startStopRecordingButton);
            recordingGroupBox.Location = new Point(12, 3);
            recordingGroupBox.Name = "recordingGroupBox";
            recordingGroupBox.Size = new Size(778, 56);
            recordingGroupBox.TabIndex = 0;
            recordingGroupBox.TabStop = false;
            recordingGroupBox.Text = "Recording Session";
            // 
            // recordingTimerLabel
            // 
            recordingTimerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            recordingTimerLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            recordingTimerLabel.Location = new Point(674, 18);
            recordingTimerLabel.Name = "recordingTimerLabel";
            recordingTimerLabel.Size = new Size(98, 32);
            recordingTimerLabel.TabIndex = 3;
            recordingTimerLabel.Text = "00:00:00";
            recordingTimerLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // openTimelogsFolderButton
            // 
            openTimelogsFolderButton.Location = new Point(200, 18);
            openTimelogsFolderButton.Name = "openTimelogsFolderButton";
            openTimelogsFolderButton.Size = new Size(188, 32);
            openTimelogsFolderButton.TabIndex = 2;
            openTimelogsFolderButton.Text = "&Open Timelogs Folder";
            openTimelogsFolderButton.UseVisualStyleBackColor = true;
            openTimelogsFolderButton.Click += OpenTimelogsFolderButton_Click;
            // 
            // startStopRecordingButton
            // 
            startStopRecordingButton.Enabled = false;
            startStopRecordingButton.Location = new Point(6, 18);
            startStopRecordingButton.Name = "startStopRecordingButton";
            startStopRecordingButton.Size = new Size(188, 32);
            startStopRecordingButton.TabIndex = 1;
            startStopRecordingButton.Text = "Start &Recording";
            startStopRecordingButton.UseVisualStyleBackColor = true;
            startStopRecordingButton.Click += StartStopRecordingButton_Click;
            // 
            // recordingTimer
            // 
            recordingTimer.Interval = 1000;
            recordingTimer.Tick += RecordingTimer_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 475);
            Controls.Add(recordingGroupBox);
            Controls.Add(tabControl);
            Controls.Add(statusLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(540, 442);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelfieStick - Multi-Device Remote";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            tabControl.ResumeLayout(false);
            timestampsTab.ResumeLayout(false);
            timestampsTab.PerformLayout();
            timestampsGroupBox.ResumeLayout(false);
            remoteTab.ResumeLayout(false);
            grpConnectedDevices.ResumeLayout(false);
            remoteControlGroupBox.ResumeLayout(false);
            remoteButtonsFlowLayoutPanel.ResumeLayout(false);
            recordingGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label statusLabel;
        private TabControl tabControl;
        private TabPage timestampsTab;
        private TabPage remoteTab;
        private GroupBox timestampsGroupBox;
        private Button newSectionButton;
        private TextBox timestampsTextBox;
        private Button censorReminderButton;
        private ListBox connectedDevicesListBox;
        private GroupBox remoteControlGroupBox;
        private Button volumeDownButton;
        private Button volumeUpButton;
        private GroupBox recordingGroupBox;
        private Button startStopRecordingButton;
        private Label recordingTimerLabel;
        private System.Windows.Forms.Timer recordingTimer;
        private Button clearTimestampsButton;
        private Button openTimelogsFolderButton;
        private Button playPauseButton;
        private Button previousButton;
        private Button nextButton;
        private GroupBox grpConnectedDevices;
        private FlowLayoutPanel remoteButtonsFlowLayoutPanel;
        private Button powerButton;
        private Button sleepButton;
        private Button wakeButton;
        private Button backButton;
        private Button homeButton;
        private Button menuButton;
        private Button googleButton;
        private Button brightnessUpButton;
        private Button brightnessDownButton;
        private Button fastForwardButton;
        private Button rewindButton;
        private Button stopButton;
        private Button muteButton;
        private Button calculatorButton;
        private Button browserButton;
        private Button calendarButton;
        private Button scrollUpButton;
        private Button scrollDownButton;
        private Button cutButton;
        private Button copyButton;
        private Button pasteButton;
        private Button selectButton;
        private Button menuUpButton;
        private Button menuDownButton;
        private Button menuLeftButton;
        private Button menuRightButton;
        private Button menuEscapeButton;
        private Button powerLongPressButton;
    }
}
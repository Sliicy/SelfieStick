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
            connectedDevicesListBox = new ListBox();
            remoteControlGroupBox = new GroupBox();
            previousButton = new Button();
            nextButton = new Button();
            playPauseButton = new Button();
            volumeDownButton = new Button();
            volumeUpButton = new Button();
            recordingGroupBox = new GroupBox();
            recordingTimerLabel = new Label();
            openTimelogsFolderButton = new Button();
            startStopRecordingButton = new Button();
            recordingTimer = new System.Windows.Forms.Timer(components);
            grpConnectedDevices = new GroupBox();
            tabControl.SuspendLayout();
            timestampsTab.SuspendLayout();
            timestampsGroupBox.SuspendLayout();
            remoteTab.SuspendLayout();
            remoteControlGroupBox.SuspendLayout();
            recordingGroupBox.SuspendLayout();
            grpConnectedDevices.SuspendLayout();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusLabel.BorderStyle = BorderStyle.Fixed3D;
            statusLabel.Location = new Point(0, 368);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(522, 27);
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
            tabControl.Size = new Size(498, 291);
            tabControl.TabIndex = 4;
            // 
            // timestampsTab
            // 
            timestampsTab.Controls.Add(timestampsGroupBox);
            timestampsTab.Controls.Add(timestampsTextBox);
            timestampsTab.Location = new Point(4, 29);
            timestampsTab.Name = "timestampsTab";
            timestampsTab.Padding = new Padding(3);
            timestampsTab.Size = new Size(490, 258);
            timestampsTab.TabIndex = 0;
            timestampsTab.Text = "Video Timestamps";
            timestampsTab.UseVisualStyleBackColor = true;
            // 
            // timestampsGroupBox
            // 
            timestampsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            timestampsGroupBox.Controls.Add(clearTimestampsButton);
            timestampsGroupBox.Controls.Add(censorReminderButton);
            timestampsGroupBox.Controls.Add(newSectionButton);
            timestampsGroupBox.Enabled = false;
            timestampsGroupBox.Location = new Point(6, 6);
            timestampsGroupBox.Name = "timestampsGroupBox";
            timestampsGroupBox.Size = new Size(200, 246);
            timestampsGroupBox.TabIndex = 5;
            timestampsGroupBox.TabStop = false;
            timestampsGroupBox.Text = "Timestamp Actions";
            // 
            // clearTimestampsButton
            // 
            clearTimestampsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clearTimestampsButton.Location = new Point(6, 203);
            clearTimestampsButton.Name = "clearTimestampsButton";
            clearTimestampsButton.Size = new Size(188, 37);
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
            censorReminderButton.Size = new Size(188, 37);
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
            newSectionButton.Size = new Size(188, 37);
            newSectionButton.TabIndex = 6;
            newSectionButton.Text = "&New Section";
            newSectionButton.UseVisualStyleBackColor = true;
            newSectionButton.Click += NewSectionButton_Click;
            // 
            // timestampsTextBox
            // 
            timestampsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            timestampsTextBox.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timestampsTextBox.Location = new Point(212, 6);
            timestampsTextBox.Multiline = true;
            timestampsTextBox.Name = "timestampsTextBox";
            timestampsTextBox.ReadOnly = true;
            timestampsTextBox.ScrollBars = ScrollBars.Vertical;
            timestampsTextBox.Size = new Size(272, 246);
            timestampsTextBox.TabIndex = 9;
            // 
            // remoteTab
            // 
            remoteTab.Controls.Add(grpConnectedDevices);
            remoteTab.Controls.Add(remoteControlGroupBox);
            remoteTab.Location = new Point(4, 29);
            remoteTab.Name = "remoteTab";
            remoteTab.Padding = new Padding(3);
            remoteTab.Size = new Size(490, 258);
            remoteTab.TabIndex = 1;
            remoteTab.Text = "Remote Control & Debug";
            remoteTab.UseVisualStyleBackColor = true;
            // 
            // connectedDevicesListBox
            // 
            connectedDevicesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            connectedDevicesListBox.FormattingEnabled = true;
            connectedDevicesListBox.Location = new Point(6, 21);
            connectedDevicesListBox.Name = "connectedDevicesListBox";
            connectedDevicesListBox.Size = new Size(206, 204);
            connectedDevicesListBox.TabIndex = 15;
            // 
            // remoteControlGroupBox
            // 
            remoteControlGroupBox.Controls.Add(previousButton);
            remoteControlGroupBox.Controls.Add(nextButton);
            remoteControlGroupBox.Controls.Add(playPauseButton);
            remoteControlGroupBox.Controls.Add(volumeDownButton);
            remoteControlGroupBox.Controls.Add(volumeUpButton);
            remoteControlGroupBox.Enabled = false;
            remoteControlGroupBox.Location = new Point(6, 6);
            remoteControlGroupBox.Name = "remoteControlGroupBox";
            remoteControlGroupBox.Size = new Size(244, 246);
            remoteControlGroupBox.TabIndex = 10;
            remoteControlGroupBox.TabStop = false;
            remoteControlGroupBox.Text = "Phone Remote Control";
            // 
            // previousButton
            // 
            previousButton.Location = new Point(23, 162);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(198, 38);
            previousButton.TabIndex = 14;
            previousButton.Text = "P&revious Track";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += previousButton_Click;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(23, 118);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(198, 38);
            nextButton.TabIndex = 13;
            nextButton.Text = "&Next Track";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // playPauseButton
            // 
            playPauseButton.Location = new Point(23, 206);
            playPauseButton.Name = "playPauseButton";
            playPauseButton.Size = new Size(198, 38);
            playPauseButton.TabIndex = 15;
            playPauseButton.Text = "P&lay/Pause";
            playPauseButton.UseVisualStyleBackColor = true;
            playPauseButton.Click += playPauseButton_Click;
            // 
            // volumeDownButton
            // 
            volumeDownButton.Location = new Point(23, 74);
            volumeDownButton.Name = "volumeDownButton";
            volumeDownButton.Size = new Size(198, 38);
            volumeDownButton.TabIndex = 12;
            volumeDownButton.Text = "Volume &Down";
            volumeDownButton.UseVisualStyleBackColor = true;
            volumeDownButton.Click += volumeDownButton_Click;
            // 
            // volumeUpButton
            // 
            volumeUpButton.Location = new Point(23, 30);
            volumeUpButton.Name = "volumeUpButton";
            volumeUpButton.Size = new Size(198, 38);
            volumeUpButton.TabIndex = 11;
            volumeUpButton.Text = "Volume &Up";
            volumeUpButton.UseVisualStyleBackColor = true;
            volumeUpButton.Click += VolumeUpButton_Click;
            // 
            // recordingGroupBox
            // 
            recordingGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            recordingGroupBox.Controls.Add(recordingTimerLabel);
            recordingGroupBox.Controls.Add(openTimelogsFolderButton);
            recordingGroupBox.Controls.Add(startStopRecordingButton);
            recordingGroupBox.Location = new Point(12, 3);
            recordingGroupBox.Name = "recordingGroupBox";
            recordingGroupBox.Size = new Size(494, 56);
            recordingGroupBox.TabIndex = 0;
            recordingGroupBox.TabStop = false;
            recordingGroupBox.Text = "Recording Session";
            // 
            // recordingTimerLabel
            // 
            recordingTimerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            recordingTimerLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            recordingTimerLabel.Location = new Point(390, 18);
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
            // grpConnectedDevices
            // 
            grpConnectedDevices.Controls.Add(connectedDevicesListBox);
            grpConnectedDevices.Location = new Point(256, 6);
            grpConnectedDevices.Name = "grpConnectedDevices";
            grpConnectedDevices.Size = new Size(218, 244);
            grpConnectedDevices.TabIndex = 16;
            grpConnectedDevices.TabStop = false;
            grpConnectedDevices.Text = "Connected Devices";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 395);
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
            remoteControlGroupBox.ResumeLayout(false);
            recordingGroupBox.ResumeLayout(false);
            grpConnectedDevices.ResumeLayout(false);
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
        private Button previousButton; // --- ADDED ---
        private Button nextButton; // --- ADDED ---
        private GroupBox grpConnectedDevices;
        // --- shutterButton was REMOVED ---
    }
}
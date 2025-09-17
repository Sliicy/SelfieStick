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
            statusLabel = new Label();
            tabControl = new TabControl();
            timestampsTab = new TabPage();
            timestampsGroupBox = new GroupBox();
            clearTimestampsButton = new Button();
            censorReminderButton = new Button();
            newSectionButton = new Button();
            timestampsTextBox = new TextBox();
            remoteTab = new TabPage();
            splitContainer1 = new SplitContainer();
            connectedDevicesListBox = new ListBox();
            label1 = new Label();
            clearLogButton = new Button();
            logTextBox = new TextBox();
            label2 = new Label();
            remoteControlGroupBox = new GroupBox();
            volumeDownButton = new Button();
            volumeUpButton = new Button();
            shutterButton = new Button();
            recordingGroupBox = new GroupBox();
            recordingTimerLabel = new Label();
            openTimelogsFolderButton = new Button();
            startStopRecordingButton = new Button();
            recordingTimer = new System.Windows.Forms.Timer(components);
            tabControl.SuspendLayout();
            timestampsTab.SuspendLayout();
            timestampsGroupBox.SuspendLayout();
            remoteTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            remoteControlGroupBox.SuspendLayout();
            recordingGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusLabel.BorderStyle = BorderStyle.Fixed3D;
            statusLabel.Location = new Point(0, 368);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(522, 27);
            statusLabel.TabIndex = 2;
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
            tabControl.TabIndex = 6;
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
            timestampsGroupBox.TabIndex = 1;
            timestampsGroupBox.TabStop = false;
            timestampsGroupBox.Text = "Timestamp Actions";
            // 
            // clearTimestampsButton
            // 
            clearTimestampsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clearTimestampsButton.Location = new Point(6, 203);
            clearTimestampsButton.Name = "clearTimestampsButton";
            clearTimestampsButton.Size = new Size(188, 37);
            clearTimestampsButton.TabIndex = 2;
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
            censorReminderButton.TabIndex = 1;
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
            newSectionButton.TabIndex = 0;
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
            timestampsTextBox.TabIndex = 0;
            // 
            // remoteTab
            // 
            remoteTab.Controls.Add(splitContainer1);
            remoteTab.Controls.Add(remoteControlGroupBox);
            remoteTab.Location = new Point(4, 29);
            remoteTab.Name = "remoteTab";
            remoteTab.Padding = new Padding(3);
            remoteTab.Size = new Size(490, 258);
            remoteTab.TabIndex = 1;
            remoteTab.Text = "Remote Control & Debug";
            remoteTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(256, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(connectedDevicesListBox);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(clearLogButton);
            splitContainer1.Panel2.Controls.Add(logTextBox);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(231, 252);
            splitContainer1.SplitterDistance = 78;
            splitContainer1.TabIndex = 8;
            // 
            // connectedDevicesListBox
            // 
            connectedDevicesListBox.FormattingEnabled = true;
            connectedDevicesListBox.Location = new Point(3, 23);
            connectedDevicesListBox.Name = "connectedDevicesListBox";
            connectedDevicesListBox.Size = new Size(225, 64);
            connectedDevicesListBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 4;
            label1.Text = "Connected Devices:";
            // 
            // clearLogButton
            // 
            clearLogButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clearLogButton.Location = new Point(134, -1);
            clearLogButton.Name = "clearLogButton";
            clearLogButton.Size = new Size(94, 29);
            clearLogButton.TabIndex = 2;
            clearLogButton.Text = "Clear Log";
            clearLogButton.UseVisualStyleBackColor = true;
            clearLogButton.Click += ClearLogButton_Click;
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.Location = new Point(3, 28);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.Size = new Size(225, 127);
            logTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 5);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 0;
            label2.Text = "BT Event Log:";
            // 
            // remoteControlGroupBox
            // 
            remoteControlGroupBox.Controls.Add(volumeDownButton);
            remoteControlGroupBox.Controls.Add(volumeUpButton);
            remoteControlGroupBox.Controls.Add(shutterButton);
            remoteControlGroupBox.Enabled = false;
            remoteControlGroupBox.Location = new Point(6, 6);
            remoteControlGroupBox.Name = "remoteControlGroupBox";
            remoteControlGroupBox.Size = new Size(244, 187);
            remoteControlGroupBox.TabIndex = 7;
            remoteControlGroupBox.TabStop = false;
            remoteControlGroupBox.Text = "Phone Remote Control";
            // 
            // volumeDownButton
            // 
            volumeDownButton.Location = new Point(23, 127);
            volumeDownButton.Name = "volumeDownButton";
            volumeDownButton.Size = new Size(198, 38);
            volumeDownButton.TabIndex = 2;
            volumeDownButton.Text = "Volume &Down";
            volumeDownButton.UseVisualStyleBackColor = true;
            volumeDownButton.Click += VolumeDownButton_Click;
            // 
            // volumeUpButton
            // 
            volumeUpButton.Location = new Point(23, 83);
            volumeUpButton.Name = "volumeUpButton";
            volumeUpButton.Size = new Size(198, 38);
            volumeUpButton.TabIndex = 1;
            volumeUpButton.Text = "Volume &Up";
            volumeUpButton.UseVisualStyleBackColor = true;
            volumeUpButton.Click += VolumeUpButton_Click;
            // 
            // shutterButton
            // 
            shutterButton.Location = new Point(23, 39);
            shutterButton.Name = "shutterButton";
            shutterButton.Size = new Size(198, 38);
            shutterButton.TabIndex = 0;
            shutterButton.Text = "Shutter / &Play";
            shutterButton.UseVisualStyleBackColor = true;
            shutterButton.Click += ShutterButton_Click;
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
            recordingGroupBox.TabIndex = 7;
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
            recordingTimerLabel.TabIndex = 1;
            recordingTimerLabel.Text = "00:00:00";
            recordingTimerLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // openTimelogsFolderButton
            // 
            openTimelogsFolderButton.Location = new Point(200, 18);
            openTimelogsFolderButton.Name = "openTimelogsFolderButton";
            openTimelogsFolderButton.Size = new Size(188, 32);
            openTimelogsFolderButton.TabIndex = 1;
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
            startStopRecordingButton.TabIndex = 0;
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
            ClientSize = new Size(522, 395);
            Controls.Add(recordingGroupBox);
            Controls.Add(tabControl);
            Controls.Add(statusLabel);
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
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            remoteControlGroupBox.ResumeLayout(false);
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
        private SplitContainer splitContainer1;
        private ListBox connectedDevicesListBox;
        private Label label1;
        private Button clearLogButton;
        private TextBox logTextBox;
        private Label label2;
        private GroupBox remoteControlGroupBox;
        private Button volumeDownButton;
        private Button volumeUpButton;
        private Button shutterButton;
        private GroupBox recordingGroupBox;
        private Button startStopRecordingButton;
        private Label recordingTimerLabel;
        private System.Windows.Forms.Timer recordingTimer;
        private Button clearTimestampsButton;
        private Button openTimelogsFolderButton;
    }
}
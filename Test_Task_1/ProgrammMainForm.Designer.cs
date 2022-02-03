namespace Test_Task_1
{
    partial class ProgrammMainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRun = new System.Windows.Forms.Button();
            this.ckbSaveLogFile = new System.Windows.Forms.CheckBox();
            this.grbRAMLoad = new System.Windows.Forms.GroupBox();
            this.lblMemoryAvailable = new System.Windows.Forms.Label();
            this.pgbProcessor = new System.Windows.Forms.ProgressBar();
            this.grbProcessorLoad = new System.Windows.Forms.GroupBox();
            this.lblProcessor = new System.Windows.Forms.Label();
            this.runTimer = new System.Windows.Forms.Timer(this.components);
            this.pfcProcessor = new System.Diagnostics.PerformanceCounter();
            this.pfcRam = new System.Diagnostics.PerformanceCounter();
            this.rbnNotepad = new System.Windows.Forms.RadioButton();
            this.rbnCmd = new System.Windows.Forms.RadioButton();
            this.grbApps = new System.Windows.Forms.GroupBox();
            this.lblWorkingSet64 = new System.Windows.Forms.Label();
            this.nudTimeSet = new System.Windows.Forms.NumericUpDown();
            this.lblSetStatistic = new System.Windows.Forms.Label();
            this.grbTestTaskParam = new System.Windows.Forms.GroupBox();
            this.lblHandleCount = new System.Windows.Forms.Label();
            this.lblPrivateBytes64 = new System.Windows.Forms.Label();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.fbdLogFile = new System.Windows.Forms.FolderBrowserDialog();
            this.grbRAMLoad.SuspendLayout();
            this.grbProcessorLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pfcProcessor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pfcRam)).BeginInit();
            this.grbApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeSet)).BeginInit();
            this.grbTestTaskParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(12, 281);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // ckbSaveLogFile
            // 
            this.ckbSaveLogFile.AutoSize = true;
            this.ckbSaveLogFile.Location = new System.Drawing.Point(12, 12);
            this.ckbSaveLogFile.Name = "ckbSaveLogFile";
            this.ckbSaveLogFile.Size = new System.Drawing.Size(103, 17);
            this.ckbSaveLogFile.TabIndex = 3;
            this.ckbSaveLogFile.Text = "Save Log File ...";
            this.ckbSaveLogFile.UseVisualStyleBackColor = true;
            this.ckbSaveLogFile.Click += new System.EventHandler(this.ckbSaveLogFile_CheckedChanged);
            // 
            // grbRAMLoad
            // 
            this.grbRAMLoad.Controls.Add(this.lblMemoryAvailable);
            this.grbRAMLoad.Location = new System.Drawing.Point(227, 80);
            this.grbRAMLoad.Name = "grbRAMLoad";
            this.grbRAMLoad.Size = new System.Drawing.Size(196, 41);
            this.grbRAMLoad.TabIndex = 7;
            this.grbRAMLoad.TabStop = false;
            this.grbRAMLoad.Text = "RAM Load...";
            this.grbRAMLoad.Visible = false;
            // 
            // lblMemoryAvailable
            // 
            this.lblMemoryAvailable.AutoSize = true;
            this.lblMemoryAvailable.Location = new System.Drawing.Point(6, 16);
            this.lblMemoryAvailable.Name = "lblMemoryAvailable";
            this.lblMemoryAvailable.Size = new System.Drawing.Size(0, 13);
            this.lblMemoryAvailable.TabIndex = 0;
            // 
            // pgbProcessor
            // 
            this.pgbProcessor.Location = new System.Drawing.Point(9, 35);
            this.pgbProcessor.Name = "pgbProcessor";
            this.pgbProcessor.Size = new System.Drawing.Size(181, 16);
            this.pgbProcessor.Step = 1;
            this.pgbProcessor.TabIndex = 0;
            // 
            // grbProcessorLoad
            // 
            this.grbProcessorLoad.Controls.Add(this.lblProcessor);
            this.grbProcessorLoad.Controls.Add(this.pgbProcessor);
            this.grbProcessorLoad.Location = new System.Drawing.Point(227, 12);
            this.grbProcessorLoad.Name = "grbProcessorLoad";
            this.grbProcessorLoad.Size = new System.Drawing.Size(196, 57);
            this.grbProcessorLoad.TabIndex = 6;
            this.grbProcessorLoad.TabStop = false;
            this.grbProcessorLoad.Text = "Processor Load ...";
            this.grbProcessorLoad.Visible = false;
            // 
            // lblProcessor
            // 
            this.lblProcessor.AutoSize = true;
            this.lblProcessor.Location = new System.Drawing.Point(10, 16);
            this.lblProcessor.Name = "lblProcessor";
            this.lblProcessor.Size = new System.Drawing.Size(0, 13);
            this.lblProcessor.TabIndex = 1;
            // 
            // runTimer
            // 
            this.runTimer.Enabled = true;
            this.runTimer.Interval = 1000;
            // 
            // pfcProcessor
            // 
            this.pfcProcessor.CategoryName = "Processor";
            this.pfcProcessor.CounterName = "% Processor Time";
            this.pfcProcessor.InstanceName = "_Total";
            // 
            // pfcRam
            // 
            this.pfcRam.CategoryName = "Memory";
            this.pfcRam.CounterName = "Available MBytes";
            // 
            // rbnNotepad
            // 
            this.rbnNotepad.AccessibleDescription = "";
            this.rbnNotepad.AccessibleName = "";
            this.rbnNotepad.AutoSize = true;
            this.rbnNotepad.Location = new System.Drawing.Point(6, 19);
            this.rbnNotepad.Name = "rbnNotepad";
            this.rbnNotepad.Size = new System.Drawing.Size(66, 17);
            this.rbnNotepad.TabIndex = 8;
            this.rbnNotepad.Tag = "notepad";
            this.rbnNotepad.Text = "Notepad";
            this.rbnNotepad.UseVisualStyleBackColor = true;
            this.rbnNotepad.CheckedChanged += new System.EventHandler(this.grbAppRadiobutton_CheckedChanged);
            // 
            // rbnCmd
            // 
            this.rbnCmd.AccessibleName = "cmd.exe";
            this.rbnCmd.AutoSize = true;
            this.rbnCmd.Location = new System.Drawing.Point(6, 42);
            this.rbnCmd.Name = "rbnCmd";
            this.rbnCmd.Size = new System.Drawing.Size(95, 17);
            this.rbnCmd.TabIndex = 10;
            this.rbnCmd.Tag = "cmd";
            this.rbnCmd.Text = "Command Line";
            this.rbnCmd.UseVisualStyleBackColor = true;
            this.rbnCmd.CheckedChanged += new System.EventHandler(this.grbAppRadiobutton_CheckedChanged);
            // 
            // grbApps
            // 
            this.grbApps.Controls.Add(this.rbnNotepad);
            this.grbApps.Controls.Add(this.rbnCmd);
            this.grbApps.Location = new System.Drawing.Point(12, 80);
            this.grbApps.Name = "grbApps";
            this.grbApps.Size = new System.Drawing.Size(119, 65);
            this.grbApps.TabIndex = 11;
            this.grbApps.TabStop = false;
            this.grbApps.Text = "Apps ...";
            this.grbApps.Visible = false;
            // 
            // lblWorkingSet64
            // 
            this.lblWorkingSet64.AutoSize = true;
            this.lblWorkingSet64.Location = new System.Drawing.Point(16, 38);
            this.lblWorkingSet64.Name = "lblWorkingSet64";
            this.lblWorkingSet64.Size = new System.Drawing.Size(0, 13);
            this.lblWorkingSet64.TabIndex = 12;
            // 
            // nudTimeSet
            // 
            this.nudTimeSet.Location = new System.Drawing.Point(12, 49);
            this.nudTimeSet.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudTimeSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeSet.Name = "nudTimeSet";
            this.nudTimeSet.Size = new System.Drawing.Size(44, 20);
            this.nudTimeSet.TabIndex = 13;
            this.nudTimeSet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSetStatistic
            // 
            this.lblSetStatistic.AutoSize = true;
            this.lblSetStatistic.Location = new System.Drawing.Point(62, 51);
            this.lblSetStatistic.Name = "lblSetStatistic";
            this.lblSetStatistic.Size = new System.Drawing.Size(144, 13);
            this.lblSetStatistic.TabIndex = 14;
            this.lblSetStatistic.Text = "Set Statistic Interval (Sec.) ...";
            // 
            // grbTestTaskParam
            // 
            this.grbTestTaskParam.Controls.Add(this.lblHandleCount);
            this.grbTestTaskParam.Controls.Add(this.lblPrivateBytes64);
            this.grbTestTaskParam.Controls.Add(this.lblProcessName);
            this.grbTestTaskParam.Controls.Add(this.lblWorkingSet64);
            this.grbTestTaskParam.Location = new System.Drawing.Point(227, 141);
            this.grbTestTaskParam.Name = "grbTestTaskParam";
            this.grbTestTaskParam.Size = new System.Drawing.Size(196, 112);
            this.grbTestTaskParam.TabIndex = 15;
            this.grbTestTaskParam.TabStop = false;
            this.grbTestTaskParam.Text = "Test Task Parameters...";
            this.grbTestTaskParam.Visible = false;
            // 
            // lblHandleCount
            // 
            this.lblHandleCount.AutoSize = true;
            this.lblHandleCount.Location = new System.Drawing.Point(16, 82);
            this.lblHandleCount.Name = "lblHandleCount";
            this.lblHandleCount.Size = new System.Drawing.Size(0, 13);
            this.lblHandleCount.TabIndex = 15;
            // 
            // lblPrivateBytes64
            // 
            this.lblPrivateBytes64.AutoSize = true;
            this.lblPrivateBytes64.Location = new System.Drawing.Point(16, 60);
            this.lblPrivateBytes64.Name = "lblPrivateBytes64";
            this.lblPrivateBytes64.Size = new System.Drawing.Size(0, 13);
            this.lblPrivateBytes64.TabIndex = 14;
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Location = new System.Drawing.Point(16, 16);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(0, 13);
            this.lblProcessName.TabIndex = 13;
            // 
            // ProgrammMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 316);
            this.Controls.Add(this.lblSetStatistic);
            this.Controls.Add(this.nudTimeSet);
            this.Controls.Add(this.grbApps);
            this.Controls.Add(this.grbRAMLoad);
            this.Controls.Add(this.grbProcessorLoad);
            this.Controls.Add(this.ckbSaveLogFile);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.grbTestTaskParam);
            this.Name = "ProgrammMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resources Control";
            this.TopMost = true;
            this.grbRAMLoad.ResumeLayout(false);
            this.grbRAMLoad.PerformLayout();
            this.grbProcessorLoad.ResumeLayout(false);
            this.grbProcessorLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pfcProcessor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pfcRam)).EndInit();
            this.grbApps.ResumeLayout(false);
            this.grbApps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeSet)).EndInit();
            this.grbTestTaskParam.ResumeLayout(false);
            this.grbTestTaskParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.CheckBox ckbSaveLogFile;
        private System.Windows.Forms.GroupBox grbRAMLoad;
        private System.Windows.Forms.ProgressBar pgbProcessor;
        private System.Windows.Forms.GroupBox grbProcessorLoad;
        private System.Windows.Forms.Label lblProcessor;
        private System.Windows.Forms.Label lblMemoryAvailable;
        private System.Windows.Forms.Timer runTimer;
        private System.Diagnostics.PerformanceCounter pfcProcessor;
        private System.Diagnostics.PerformanceCounter pfcRam;
        private System.Windows.Forms.RadioButton rbnNotepad;
        private System.Windows.Forms.RadioButton rbnCmd;
        private System.Windows.Forms.GroupBox grbApps;
        private System.Windows.Forms.Label lblWorkingSet64;
        private System.Windows.Forms.NumericUpDown nudTimeSet;
        private System.Windows.Forms.Label lblSetStatistic;
        private System.Windows.Forms.GroupBox grbTestTaskParam;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Label lblPrivateBytes64;
        private System.Windows.Forms.Label lblHandleCount;
        private System.Windows.Forms.FolderBrowserDialog fbdLogFile;
    }
}


namespace ROMLaunch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddEmulator = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveEmulator = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditEmuName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditEmuExe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditROMPath = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditROMFileExtensions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabROMSelector = new System.Windows.Forms.TabControl();
            this.btnLaunchROM = new System.Windows.Forms.Button();
            this.btnOpenEmulator = new System.Windows.Forms.Button();
            this.mnuEditEmulatorArgs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.editToolStripMenuItem,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddEmulator,
            this.mnuRemoveEmulator,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuAddEmulator
            // 
            this.mnuAddEmulator.Name = "mnuAddEmulator";
            this.mnuAddEmulator.Size = new System.Drawing.Size(168, 22);
            this.mnuAddEmulator.Text = "Add Emulator...";
            this.mnuAddEmulator.Click += new System.EventHandler(this.mnuAddEmulator_Click);
            // 
            // mnuRemoveEmulator
            // 
            this.mnuRemoveEmulator.Name = "mnuRemoveEmulator";
            this.mnuRemoveEmulator.Size = new System.Drawing.Size(168, 22);
            this.mnuRemoveEmulator.Text = "Remove Emulator";
            this.mnuRemoveEmulator.Click += new System.EventHandler(this.mnuRemoveEmulator_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(168, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditEmuName,
            this.mnuEditEmuExe,
            this.mnuEditEmulatorArgs,
            this.mnuEditROMPath,
            this.mnuEditROMFileExtensions});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnuEditEmuName
            // 
            this.mnuEditEmuName.Name = "mnuEditEmuName";
            this.mnuEditEmuName.Size = new System.Drawing.Size(193, 22);
            this.mnuEditEmuName.Text = "Emulator Name";
            this.mnuEditEmuName.Click += new System.EventHandler(this.mnuEditEmuName_Click);
            // 
            // mnuEditEmuExe
            // 
            this.mnuEditEmuExe.Name = "mnuEditEmuExe";
            this.mnuEditEmuExe.Size = new System.Drawing.Size(193, 22);
            this.mnuEditEmuExe.Text = "Emulator Executable...";
            this.mnuEditEmuExe.Click += new System.EventHandler(this.mnuEditEmuExe_Click);
            // 
            // mnuEditROMPath
            // 
            this.mnuEditROMPath.Name = "mnuEditROMPath";
            this.mnuEditROMPath.Size = new System.Drawing.Size(193, 22);
            this.mnuEditROMPath.Text = "ROM Path...";
            this.mnuEditROMPath.Click += new System.EventHandler(this.mnuEditROMPath_Click);
            // 
            // mnuEditROMFileExtensions
            // 
            this.mnuEditROMFileExtensions.Name = "mnuEditROMFileExtensions";
            this.mnuEditROMFileExtensions.Size = new System.Drawing.Size(193, 22);
            this.mnuEditROMFileExtensions.Text = "ROM File Extensions...";
            this.mnuEditROMFileExtensions.Click += new System.EventHandler(this.mnuEditROMFileExtensions_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // tabROMSelector
            // 
            this.tabROMSelector.Location = new System.Drawing.Point(12, 27);
            this.tabROMSelector.Name = "tabROMSelector";
            this.tabROMSelector.SelectedIndex = 0;
            this.tabROMSelector.Size = new System.Drawing.Size(600, 349);
            this.tabROMSelector.TabIndex = 1;
            // 
            // btnLaunchROM
            // 
            this.btnLaunchROM.Location = new System.Drawing.Point(492, 382);
            this.btnLaunchROM.Name = "btnLaunchROM";
            this.btnLaunchROM.Size = new System.Drawing.Size(120, 48);
            this.btnLaunchROM.TabIndex = 2;
            this.btnLaunchROM.Text = "Launch ROM";
            this.btnLaunchROM.UseVisualStyleBackColor = true;
            this.btnLaunchROM.Click += new System.EventHandler(this.btnLaunchROM_Click);
            // 
            // btnOpenEmulator
            // 
            this.btnOpenEmulator.Location = new System.Drawing.Point(12, 382);
            this.btnOpenEmulator.Name = "btnOpenEmulator";
            this.btnOpenEmulator.Size = new System.Drawing.Size(120, 48);
            this.btnOpenEmulator.TabIndex = 3;
            this.btnOpenEmulator.Text = "Open Emulator";
            this.btnOpenEmulator.UseVisualStyleBackColor = true;
            this.btnOpenEmulator.Click += new System.EventHandler(this.btnOpenEmulator_Click);
            // 
            // mnuEditEmulatorArgs
            // 
            this.mnuEditEmulatorArgs.Name = "mnuEditEmulatorArgs";
            this.mnuEditEmulatorArgs.Size = new System.Drawing.Size(193, 22);
            this.mnuEditEmulatorArgs.Text = "Emulator Arguments...";
            this.mnuEditEmulatorArgs.Click += new System.EventHandler(this.mnuEditEmulatorArgs_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.btnOpenEmulator);
            this.Controls.Add(this.btnLaunchROM);
            this.Controls.Add(this.tabROMSelector);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ROMLaunch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuAddEmulator;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveEmulator;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.TabControl tabROMSelector;
        private System.Windows.Forms.Button btnLaunchROM;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditEmuName;
        private System.Windows.Forms.ToolStripMenuItem mnuEditEmuExe;
        private System.Windows.Forms.ToolStripMenuItem mnuEditROMPath;
        private System.Windows.Forms.ToolStripMenuItem mnuEditROMFileExtensions;
        private System.Windows.Forms.Button btnOpenEmulator;
        private System.Windows.Forms.ToolStripMenuItem mnuEditEmulatorArgs;
    }
}


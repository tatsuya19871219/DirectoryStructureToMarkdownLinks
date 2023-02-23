namespace DirectoryStructureToMarkdownLinks
{
    partial class SettingsForm
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
            this.checkedListBoxSettings = new System.Windows.Forms.CheckedListBox();
            this.labelMaxDepth = new System.Windows.Forms.Label();
            this.autoChechMaxDepth = new System.Windows.Forms.NumericUpDown();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelIgnoreDirs = new System.Windows.Forms.Label();
            this.labelIgnoreFiles = new System.Windows.Forms.Label();
            this.buttonAddIgnoreDir = new System.Windows.Forms.Button();
            this.buttonButtonIgnoreDir = new System.Windows.Forms.Button();
            this.buttonRemoveIgnoreFile = new System.Windows.Forms.Button();
            this.buttonAddIgnoreFile = new System.Windows.Forms.Button();
            this.labelExplaination = new System.Windows.Forms.Label();
            this.listIgnoreDirs = new System.Windows.Forms.ListView();
            this.listIgnoreFiles = new System.Windows.Forms.ListView();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.autoChechMaxDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxSettings
            // 
            this.checkedListBoxSettings.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxSettings.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkedListBoxSettings.FormattingEnabled = true;
            this.checkedListBoxSettings.Items.AddRange(new object[] {
            "Allow to expand dot directories (.[dirname])",
            "Disable warning \'README.md is not found\'",
            "Enable auto checking when opening new directory"});
            this.checkedListBoxSettings.Location = new System.Drawing.Point(39, 190);
            this.checkedListBoxSettings.Name = "checkedListBoxSettings";
            this.checkedListBoxSettings.Size = new System.Drawing.Size(385, 76);
            this.checkedListBoxSettings.TabIndex = 0;
            // 
            // labelMaxDepth
            // 
            this.labelMaxDepth.AutoSize = true;
            this.labelMaxDepth.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMaxDepth.Location = new System.Drawing.Point(57, 292);
            this.labelMaxDepth.Name = "labelMaxDepth";
            this.labelMaxDepth.Size = new System.Drawing.Size(160, 21);
            this.labelMaxDepth.TabIndex = 1;
            this.labelMaxDepth.Text = "AutoCheck MaxDepth";
            // 
            // autoChechMaxDepth
            // 
            this.autoChechMaxDepth.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.autoChechMaxDepth.Location = new System.Drawing.Point(223, 290);
            this.autoChechMaxDepth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.autoChechMaxDepth.Name = "autoChechMaxDepth";
            this.autoChechMaxDepth.Size = new System.Drawing.Size(42, 29);
            this.autoChechMaxDepth.TabIndex = 2;
            // 
            // buttonApply
            // 
            this.buttonApply.AutoSize = true;
            this.buttonApply.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonApply.Location = new System.Drawing.Point(352, 287);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 31);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelIgnoreDirs
            // 
            this.labelIgnoreDirs.AutoSize = true;
            this.labelIgnoreDirs.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelIgnoreDirs.Location = new System.Drawing.Point(57, 33);
            this.labelIgnoreDirs.Name = "labelIgnoreDirs";
            this.labelIgnoreDirs.Size = new System.Drawing.Size(134, 21);
            this.labelIgnoreDirs.TabIndex = 4;
            this.labelIgnoreDirs.Text = "Ignore Directories";
            // 
            // labelIgnoreFiles
            // 
            this.labelIgnoreFiles.AutoSize = true;
            this.labelIgnoreFiles.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelIgnoreFiles.Location = new System.Drawing.Point(285, 33);
            this.labelIgnoreFiles.Name = "labelIgnoreFiles";
            this.labelIgnoreFiles.Size = new System.Drawing.Size(90, 21);
            this.labelIgnoreFiles.TabIndex = 5;
            this.labelIgnoreFiles.Text = "Ignore Files";
            // 
            // buttonAddIgnoreDir
            // 
            this.buttonAddIgnoreDir.Location = new System.Drawing.Point(48, 140);
            this.buttonAddIgnoreDir.Name = "buttonAddIgnoreDir";
            this.buttonAddIgnoreDir.Size = new System.Drawing.Size(75, 23);
            this.buttonAddIgnoreDir.TabIndex = 7;
            this.buttonAddIgnoreDir.Text = "Add";
            this.buttonAddIgnoreDir.UseVisualStyleBackColor = true;
            // 
            // buttonButtonIgnoreDir
            // 
            this.buttonButtonIgnoreDir.Location = new System.Drawing.Point(129, 140);
            this.buttonButtonIgnoreDir.Name = "buttonButtonIgnoreDir";
            this.buttonButtonIgnoreDir.Size = new System.Drawing.Size(75, 23);
            this.buttonButtonIgnoreDir.TabIndex = 8;
            this.buttonButtonIgnoreDir.Text = "Remove";
            this.buttonButtonIgnoreDir.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveIgnoreFile
            // 
            this.buttonRemoveIgnoreFile.Location = new System.Drawing.Point(344, 140);
            this.buttonRemoveIgnoreFile.Name = "buttonRemoveIgnoreFile";
            this.buttonRemoveIgnoreFile.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveIgnoreFile.TabIndex = 11;
            this.buttonRemoveIgnoreFile.Text = "Remove";
            this.buttonRemoveIgnoreFile.UseVisualStyleBackColor = true;
            // 
            // buttonAddIgnoreFile
            // 
            this.buttonAddIgnoreFile.Location = new System.Drawing.Point(263, 140);
            this.buttonAddIgnoreFile.Name = "buttonAddIgnoreFile";
            this.buttonAddIgnoreFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAddIgnoreFile.TabIndex = 10;
            this.buttonAddIgnoreFile.Text = "Add";
            this.buttonAddIgnoreFile.UseVisualStyleBackColor = true;
            // 
            // labelExplaination
            // 
            this.labelExplaination.AutoSize = true;
            this.labelExplaination.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelExplaination.Location = new System.Drawing.Point(48, -9);
            this.labelExplaination.Name = "labelExplaination";
            this.labelExplaination.Size = new System.Drawing.Size(354, 42);
            this.labelExplaination.TabIndex = 13;
            this.labelExplaination.Text = "The program ignores following lists.\r\n You can still expand and/or check them man" +
    "ually.";
            // 
            // listIgnoreDirs
            // 
            this.listIgnoreDirs.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listIgnoreDirs.LabelEdit = true;
            this.listIgnoreDirs.LabelWrap = false;
            this.listIgnoreDirs.Location = new System.Drawing.Point(48, 57);
            this.listIgnoreDirs.Name = "listIgnoreDirs";
            this.listIgnoreDirs.Size = new System.Drawing.Size(156, 77);
            this.listIgnoreDirs.TabIndex = 14;
            this.listIgnoreDirs.TileSize = new System.Drawing.Size(150, 15);
            this.listIgnoreDirs.UseCompatibleStateImageBehavior = false;
            this.listIgnoreDirs.View = System.Windows.Forms.View.Tile;
            this.listIgnoreDirs.DoubleClick += new System.EventHandler(this.listIgnoreDirs_DoubleClick);
            // 
            // listIgnoreFiles
            // 
            this.listIgnoreFiles.LabelEdit = true;
            this.listIgnoreFiles.LabelWrap = false;
            this.listIgnoreFiles.Location = new System.Drawing.Point(263, 57);
            this.listIgnoreFiles.Name = "listIgnoreFiles";
            this.listIgnoreFiles.Size = new System.Drawing.Size(156, 77);
            this.listIgnoreFiles.TabIndex = 15;
            this.listIgnoreFiles.TileSize = new System.Drawing.Size(150, 15);
            this.listIgnoreFiles.UseCompatibleStateImageBehavior = false;
            this.listIgnoreFiles.View = System.Windows.Forms.View.Tile;
            // 
            // buttonReset
            // 
            this.buttonReset.AutoSize = true;
            this.buttonReset.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReset.Location = new System.Drawing.Point(271, 287);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 31);
            this.buttonReset.TabIndex = 16;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 337);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.listIgnoreFiles);
            this.Controls.Add(this.listIgnoreDirs);
            this.Controls.Add(this.labelExplaination);
            this.Controls.Add(this.buttonRemoveIgnoreFile);
            this.Controls.Add(this.buttonAddIgnoreFile);
            this.Controls.Add(this.buttonButtonIgnoreDir);
            this.Controls.Add(this.buttonAddIgnoreDir);
            this.Controls.Add(this.labelIgnoreFiles);
            this.Controls.Add(this.labelIgnoreDirs);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.autoChechMaxDepth);
            this.Controls.Add(this.labelMaxDepth);
            this.Controls.Add(this.checkedListBoxSettings);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.autoChechMaxDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox checkedListBoxSettings;
        private Label labelMaxDepth;
        private NumericUpDown autoChechMaxDepth;
        private Button buttonApply;
        private Label labelIgnoreDirs;
        private Label labelIgnoreFiles;
        private Button buttonAddIgnoreDir;
        private Button buttonButtonIgnoreDir;
        private Button buttonRemoveIgnoreFile;
        private Button buttonAddIgnoreFile;
        private Label labelExplaination;
        private ListView listIgnoreDirs;
        private ListView listIgnoreFiles;
        private Button buttonReset;
    }
}
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
            checkedListBoxSettings = new CheckedListBox();
            labelMaxDepth = new Label();
            autoCheckMaxDepth = new NumericUpDown();
            buttonApply = new Button();
            labelIgnoreDirs = new Label();
            labelIgnoreFiles = new Label();
            buttonAddIgnoreDir = new Button();
            buttonRemoveIgnoreDir = new Button();
            buttonRemoveIgnoreFile = new Button();
            buttonAddIgnoreFile = new Button();
            labelExplaination = new Label();
            listIgnoreDirs = new ListView();
            listIgnoreFiles = new ListView();
            buttonReset = new Button();
            buttonDefault = new Button();
            ((System.ComponentModel.ISupportInitialize)autoCheckMaxDepth).BeginInit();
            SuspendLayout();
            // 
            // checkedListBoxSettings
            // 
            checkedListBoxSettings.BackColor = SystemColors.Control;
            checkedListBoxSettings.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkedListBoxSettings.FormattingEnabled = true;
            checkedListBoxSettings.Items.AddRange(new object[] { "Checked list here" });
            checkedListBoxSettings.Location = new Point(39, 229);
            checkedListBoxSettings.Name = "checkedListBoxSettings";
            checkedListBoxSettings.Size = new Size(385, 40);
            checkedListBoxSettings.TabIndex = 0;
            // 
            // labelMaxDepth
            // 
            labelMaxDepth.AutoSize = true;
            labelMaxDepth.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelMaxDepth.Location = new Point(57, 298);
            labelMaxDepth.Name = "labelMaxDepth";
            labelMaxDepth.Size = new Size(123, 15);
            labelMaxDepth.TabIndex = 1;
            labelMaxDepth.Text = "AutoCheck MaxDepth";
            // 
            // autoCheckMaxDepth
            // 
            autoCheckMaxDepth.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            autoCheckMaxDepth.Location = new Point(186, 296);
            autoCheckMaxDepth.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            autoCheckMaxDepth.Name = "autoCheckMaxDepth";
            autoCheckMaxDepth.Size = new Size(42, 23);
            autoCheckMaxDepth.TabIndex = 2;
            // 
            // buttonApply
            // 
            buttonApply.AutoSize = true;
            buttonApply.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonApply.Location = new Point(369, 353);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(75, 31);
            buttonApply.TabIndex = 3;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // labelIgnoreDirs
            // 
            labelIgnoreDirs.AutoSize = true;
            labelIgnoreDirs.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelIgnoreDirs.Location = new Point(48, 78);
            labelIgnoreDirs.Name = "labelIgnoreDirs";
            labelIgnoreDirs.Size = new Size(102, 15);
            labelIgnoreDirs.TabIndex = 4;
            labelIgnoreDirs.Text = "Ignore Directories";
            // 
            // labelIgnoreFiles
            // 
            labelIgnoreFiles.AutoSize = true;
            labelIgnoreFiles.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelIgnoreFiles.Location = new Point(263, 78);
            labelIgnoreFiles.Name = "labelIgnoreFiles";
            labelIgnoreFiles.Size = new Size(68, 15);
            labelIgnoreFiles.TabIndex = 5;
            labelIgnoreFiles.Text = "Ignore Files";
            // 
            // buttonAddIgnoreDir
            // 
            buttonAddIgnoreDir.Location = new Point(48, 179);
            buttonAddIgnoreDir.Name = "buttonAddIgnoreDir";
            buttonAddIgnoreDir.Size = new Size(75, 23);
            buttonAddIgnoreDir.TabIndex = 7;
            buttonAddIgnoreDir.Text = "Add";
            buttonAddIgnoreDir.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveIgnoreDir
            // 
            buttonRemoveIgnoreDir.Location = new Point(129, 179);
            buttonRemoveIgnoreDir.Name = "buttonRemoveIgnoreDir";
            buttonRemoveIgnoreDir.Size = new Size(75, 23);
            buttonRemoveIgnoreDir.TabIndex = 8;
            buttonRemoveIgnoreDir.Text = "Remove";
            buttonRemoveIgnoreDir.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveIgnoreFile
            // 
            buttonRemoveIgnoreFile.Location = new Point(344, 179);
            buttonRemoveIgnoreFile.Name = "buttonRemoveIgnoreFile";
            buttonRemoveIgnoreFile.Size = new Size(75, 23);
            buttonRemoveIgnoreFile.TabIndex = 11;
            buttonRemoveIgnoreFile.Text = "Remove";
            buttonRemoveIgnoreFile.UseVisualStyleBackColor = true;
            // 
            // buttonAddIgnoreFile
            // 
            buttonAddIgnoreFile.Location = new Point(263, 179);
            buttonAddIgnoreFile.Name = "buttonAddIgnoreFile";
            buttonAddIgnoreFile.Size = new Size(75, 23);
            buttonAddIgnoreFile.TabIndex = 10;
            buttonAddIgnoreFile.Text = "Add";
            buttonAddIgnoreFile.UseVisualStyleBackColor = true;
            // 
            // labelExplaination
            // 
            labelExplaination.AutoSize = true;
            labelExplaination.Font = new Font("Yu Gothic UI", 12F, FontStyle.Underline, GraphicsUnit.Point);
            labelExplaination.Location = new Point(29, 18);
            labelExplaination.Name = "labelExplaination";
            labelExplaination.Size = new Size(415, 42);
            labelExplaination.TabIndex = 13;
            labelExplaination.Text = "The program ignores  files/dirs matches the following lists.\r\n You can still expand and/or check them manually.";
            // 
            // listIgnoreDirs
            // 
            listIgnoreDirs.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listIgnoreDirs.LabelEdit = true;
            listIgnoreDirs.LabelWrap = false;
            listIgnoreDirs.Location = new Point(48, 96);
            listIgnoreDirs.Name = "listIgnoreDirs";
            listIgnoreDirs.Size = new Size(156, 77);
            listIgnoreDirs.TabIndex = 14;
            listIgnoreDirs.TileSize = new Size(150, 15);
            listIgnoreDirs.UseCompatibleStateImageBehavior = false;
            listIgnoreDirs.View = View.Tile;
            // 
            // listIgnoreFiles
            // 
            listIgnoreFiles.LabelEdit = true;
            listIgnoreFiles.LabelWrap = false;
            listIgnoreFiles.Location = new Point(263, 96);
            listIgnoreFiles.Name = "listIgnoreFiles";
            listIgnoreFiles.Size = new Size(156, 77);
            listIgnoreFiles.TabIndex = 15;
            listIgnoreFiles.TileSize = new Size(150, 15);
            listIgnoreFiles.UseCompatibleStateImageBehavior = false;
            listIgnoreFiles.View = View.Tile;
            // 
            // buttonReset
            // 
            buttonReset.AutoSize = true;
            buttonReset.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonReset.Location = new Point(288, 353);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(75, 31);
            buttonReset.TabIndex = 16;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonDefault
            // 
            buttonDefault.AutoSize = true;
            buttonDefault.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDefault.Location = new Point(12, 353);
            buttonDefault.Name = "buttonDefault";
            buttonDefault.Size = new Size(75, 31);
            buttonDefault.TabIndex = 17;
            buttonDefault.Text = "Default";
            buttonDefault.UseVisualStyleBackColor = true;
            buttonDefault.Click += buttonDefault_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 393);
            Controls.Add(buttonDefault);
            Controls.Add(buttonReset);
            Controls.Add(listIgnoreFiles);
            Controls.Add(listIgnoreDirs);
            Controls.Add(labelExplaination);
            Controls.Add(buttonRemoveIgnoreFile);
            Controls.Add(buttonAddIgnoreFile);
            Controls.Add(buttonRemoveIgnoreDir);
            Controls.Add(buttonAddIgnoreDir);
            Controls.Add(labelIgnoreFiles);
            Controls.Add(labelIgnoreDirs);
            Controls.Add(buttonApply);
            Controls.Add(autoCheckMaxDepth);
            Controls.Add(labelMaxDepth);
            Controls.Add(checkedListBoxSettings);
            Name = "SettingsForm";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)autoCheckMaxDepth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBoxSettings;
        private Label labelMaxDepth;
        private NumericUpDown autoCheckMaxDepth;
        private Button buttonApply;
        private Label labelIgnoreDirs;
        private Label labelIgnoreFiles;
        private Button buttonAddIgnoreDir;
        private Button buttonRemoveIgnoreDir;
        private Button buttonRemoveIgnoreFile;
        private Button buttonAddIgnoreFile;
        private Label labelExplaination;
        private ListView listIgnoreDirs;
        private ListView listIgnoreFiles;
        private Button buttonReset;
        private Button buttonDefault;
    }
}
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
            this.checkedListBoxSettings.Location = new System.Drawing.Point(42, 34);
            this.checkedListBoxSettings.Name = "checkedListBoxSettings";
            this.checkedListBoxSettings.Size = new System.Drawing.Size(385, 76);
            this.checkedListBoxSettings.TabIndex = 0;
            // 
            // labelMaxDepth
            // 
            this.labelMaxDepth.AutoSize = true;
            this.labelMaxDepth.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMaxDepth.Location = new System.Drawing.Point(60, 136);
            this.labelMaxDepth.Name = "labelMaxDepth";
            this.labelMaxDepth.Size = new System.Drawing.Size(160, 21);
            this.labelMaxDepth.TabIndex = 1;
            this.labelMaxDepth.Text = "AutoCheck MaxDepth";
            // 
            // autoChechMaxDepth
            // 
            this.autoChechMaxDepth.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.autoChechMaxDepth.Location = new System.Drawing.Point(226, 134);
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
            this.buttonApply.Location = new System.Drawing.Point(352, 131);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 31);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 178);
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
    }
}
namespace MCDFiscalManager.WinFormsInterface.OfdDataSubForms
{
    partial class OfdForm
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
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.ofdGroupBox = new System.Windows.Forms.GroupBox();
            this.tinTextBox = new System.Windows.Forms.TextBox();
            this.tinLabel = new System.Windows.Forms.Label();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.ofdCancelButton = new System.Windows.Forms.Button();
            this.ofdOkButton = new System.Windows.Forms.Button();
            this.ofdClearButton = new System.Windows.Forms.Button();
            this.ofdGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(97, 30);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(351, 20);
            this.fullNameTextBox.TabIndex = 1;
            // 
            // ofdGroupBox
            // 
            this.ofdGroupBox.Controls.Add(this.tinTextBox);
            this.ofdGroupBox.Controls.Add(this.tinLabel);
            this.ofdGroupBox.Controls.Add(this.fullNameTextBox);
            this.ofdGroupBox.Controls.Add(this.fullNameLabel);
            this.ofdGroupBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ofdGroupBox.Location = new System.Drawing.Point(11, 11);
            this.ofdGroupBox.Name = "ofdGroupBox";
            this.ofdGroupBox.Size = new System.Drawing.Size(460, 104);
            this.ofdGroupBox.TabIndex = 10;
            this.ofdGroupBox.TabStop = false;
            this.ofdGroupBox.Text = "ОФД";
            // 
            // tinTextBox
            // 
            this.tinTextBox.Location = new System.Drawing.Point(95, 69);
            this.tinTextBox.Name = "tinTextBox";
            this.tinTextBox.Size = new System.Drawing.Size(353, 20);
            this.tinTextBox.TabIndex = 3;
            // 
            // tinLabel
            // 
            this.tinLabel.AutoSize = true;
            this.tinLabel.Location = new System.Drawing.Point(58, 72);
            this.tinLabel.Name = "tinLabel";
            this.tinLabel.Size = new System.Drawing.Size(31, 13);
            this.tinLabel.TabIndex = 2;
            this.tinLabel.Text = "ИНН";
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Location = new System.Drawing.Point(6, 33);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(83, 13);
            this.fullNameLabel.TabIndex = 0;
            this.fullNameLabel.Text = "Наименование";
            // 
            // ofdCancelButton
            // 
            this.ofdCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ofdCancelButton.Location = new System.Drawing.Point(204, 121);
            this.ofdCancelButton.Name = "ofdCancelButton";
            this.ofdCancelButton.Size = new System.Drawing.Size(75, 23);
            this.ofdCancelButton.TabIndex = 9;
            this.ofdCancelButton.Text = "Отмена";
            this.ofdCancelButton.UseVisualStyleBackColor = true;
            // 
            // ofdOkButton
            // 
            this.ofdOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ofdOkButton.Location = new System.Drawing.Point(63, 121);
            this.ofdOkButton.Name = "ofdOkButton";
            this.ofdOkButton.Size = new System.Drawing.Size(75, 23);
            this.ofdOkButton.TabIndex = 8;
            this.ofdOkButton.Text = "Ok";
            this.ofdOkButton.UseVisualStyleBackColor = true;
            // 
            // ofdClearButton
            // 
            this.ofdClearButton.Location = new System.Drawing.Point(384, 121);
            this.ofdClearButton.Name = "ofdClearButton";
            this.ofdClearButton.Size = new System.Drawing.Size(75, 23);
            this.ofdClearButton.TabIndex = 11;
            this.ofdClearButton.Text = "Очистить";
            this.ofdClearButton.UseVisualStyleBackColor = true;
            this.ofdClearButton.Click += new System.EventHandler(this.ofdClearButton_Click);
            // 
            // OfdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 158);
            this.Controls.Add(this.ofdGroupBox);
            this.Controls.Add(this.ofdCancelButton);
            this.Controls.Add(this.ofdOkButton);
            this.Controls.Add(this.ofdClearButton);
            this.Name = "OfdForm";
            this.Text = "ОФД";
            this.ofdGroupBox.ResumeLayout(false);
            this.ofdGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected internal System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.GroupBox ofdGroupBox;
        protected internal System.Windows.Forms.TextBox tinTextBox;
        private System.Windows.Forms.Label tinLabel;
        private System.Windows.Forms.Label fullNameLabel;
        protected internal System.Windows.Forms.Button ofdCancelButton;
        protected internal System.Windows.Forms.Button ofdOkButton;
        private System.Windows.Forms.Button ofdClearButton;
    }
}
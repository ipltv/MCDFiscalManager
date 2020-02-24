namespace MCDFiscalManager.WinFormsInterface.CompanyDataSubForms
{
    partial class CompanyForm
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
            this.AddCompanyOkButton = new System.Windows.Forms.Button();
            this.AddCompanyCancelButton = new System.Windows.Forms.Button();
            this.companyAddGroupBox = new System.Windows.Forms.GroupBox();
            this.companyTINTextBox = new System.Windows.Forms.TextBox();
            this.companyTINLabel = new System.Windows.Forms.Label();
            this.companyShortNameTextBox = new System.Windows.Forms.TextBox();
            this.companyShortNameLabel = new System.Windows.Forms.Label();
            this.companyFullNameTextBox = new System.Windows.Forms.TextBox();
            this.companyFullNameLabel = new System.Windows.Forms.Label();
            this.companyClearButton = new System.Windows.Forms.Button();
            this.companyAddGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddCompanyOkButton
            // 
            this.AddCompanyOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddCompanyOkButton.Location = new System.Drawing.Point(194, 172);
            this.AddCompanyOkButton.Name = "AddCompanyOkButton";
            this.AddCompanyOkButton.Size = new System.Drawing.Size(75, 23);
            this.AddCompanyOkButton.TabIndex = 0;
            this.AddCompanyOkButton.Text = "Ok";
            this.AddCompanyOkButton.UseVisualStyleBackColor = true;
            // 
            // AddCompanyCancelButton
            // 
            this.AddCompanyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AddCompanyCancelButton.Location = new System.Drawing.Point(335, 172);
            this.AddCompanyCancelButton.Name = "AddCompanyCancelButton";
            this.AddCompanyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AddCompanyCancelButton.TabIndex = 1;
            this.AddCompanyCancelButton.Text = "Отмена";
            this.AddCompanyCancelButton.UseVisualStyleBackColor = true;
            // 
            // companyAddGroupBox
            // 
            this.companyAddGroupBox.Controls.Add(this.companyTINTextBox);
            this.companyAddGroupBox.Controls.Add(this.companyTINLabel);
            this.companyAddGroupBox.Controls.Add(this.companyShortNameTextBox);
            this.companyAddGroupBox.Controls.Add(this.companyShortNameLabel);
            this.companyAddGroupBox.Controls.Add(this.companyFullNameTextBox);
            this.companyAddGroupBox.Controls.Add(this.companyFullNameLabel);
            this.companyAddGroupBox.Location = new System.Drawing.Point(12, 12);
            this.companyAddGroupBox.Name = "companyAddGroupBox";
            this.companyAddGroupBox.Size = new System.Drawing.Size(578, 148);
            this.companyAddGroupBox.TabIndex = 2;
            this.companyAddGroupBox.TabStop = false;
            this.companyAddGroupBox.Text = "Компания";
            // 
            // companyTINTextBox
            // 
            this.companyTINTextBox.Location = new System.Drawing.Point(220, 104);
            this.companyTINTextBox.Name = "companyTINTextBox";
            this.companyTINTextBox.Size = new System.Drawing.Size(344, 20);
            this.companyTINTextBox.TabIndex = 5;
            // 
            // companyTINLabel
            // 
            this.companyTINLabel.AutoSize = true;
            this.companyTINLabel.Location = new System.Drawing.Point(179, 111);
            this.companyTINLabel.Name = "companyTINLabel";
            this.companyTINLabel.Size = new System.Drawing.Size(31, 13);
            this.companyTINLabel.TabIndex = 4;
            this.companyTINLabel.Text = "ИНН";
            // 
            // companyShortNameTextBox
            // 
            this.companyShortNameTextBox.Location = new System.Drawing.Point(220, 69);
            this.companyShortNameTextBox.Name = "companyShortNameTextBox";
            this.companyShortNameTextBox.Size = new System.Drawing.Size(344, 20);
            this.companyShortNameTextBox.TabIndex = 3;
            // 
            // companyShortNameLabel
            // 
            this.companyShortNameLabel.AutoSize = true;
            this.companyShortNameLabel.Location = new System.Drawing.Point(6, 76);
            this.companyShortNameLabel.Name = "companyShortNameLabel";
            this.companyShortNameLabel.Size = new System.Drawing.Size(207, 13);
            this.companyShortNameLabel.TabIndex = 2;
            this.companyShortNameLabel.Text = "Сокращенное наименование компании";
            // 
            // companyFullNameTextBox
            // 
            this.companyFullNameTextBox.Location = new System.Drawing.Point(220, 30);
            this.companyFullNameTextBox.Name = "companyFullNameTextBox";
            this.companyFullNameTextBox.Size = new System.Drawing.Size(344, 20);
            this.companyFullNameTextBox.TabIndex = 1;
            // 
            // companyFullNameLabel
            // 
            this.companyFullNameLabel.AutoSize = true;
            this.companyFullNameLabel.Location = new System.Drawing.Point(35, 37);
            this.companyFullNameLabel.Name = "companyFullNameLabel";
            this.companyFullNameLabel.Size = new System.Drawing.Size(175, 13);
            this.companyFullNameLabel.TabIndex = 0;
            this.companyFullNameLabel.Text = "Полное наименование компании";
            // 
            // companyClearButton
            // 
            this.companyClearButton.Location = new System.Drawing.Point(515, 172);
            this.companyClearButton.Name = "companyClearButton";
            this.companyClearButton.Size = new System.Drawing.Size(75, 23);
            this.companyClearButton.TabIndex = 3;
            this.companyClearButton.Text = "Очистить";
            this.companyClearButton.UseVisualStyleBackColor = true;
            this.companyClearButton.Click += new System.EventHandler(this.companyClearButton_Click);
            // 
            // CompanyAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 202);
            this.Controls.Add(this.companyClearButton);
            this.Controls.Add(this.companyAddGroupBox);
            this.Controls.Add(this.AddCompanyCancelButton);
            this.Controls.Add(this.AddCompanyOkButton);
            this.Name = "CompanyAddForm";
            this.Text = "Добавить компанию";
            this.companyAddGroupBox.ResumeLayout(false);
            this.companyAddGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddCompanyOkButton;
        private System.Windows.Forms.Button AddCompanyCancelButton;
        private System.Windows.Forms.GroupBox companyAddGroupBox;
        private System.Windows.Forms.Label companyFullNameLabel;
        private System.Windows.Forms.Label companyTINLabel;
        private System.Windows.Forms.Label companyShortNameLabel;
        private System.Windows.Forms.Button companyClearButton;
        protected internal System.Windows.Forms.TextBox companyFullNameTextBox;
        protected internal System.Windows.Forms.TextBox companyTINTextBox;
        protected internal System.Windows.Forms.TextBox companyShortNameTextBox;
    }
}
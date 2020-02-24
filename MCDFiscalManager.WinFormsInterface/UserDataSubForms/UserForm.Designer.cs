namespace MCDFiscalManager.WinFormsInterface.UserDataSubForms
{
    partial class UserForm
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
            this.userGroupBox = new System.Windows.Forms.GroupBox();
            this.patronymicTextBox = new System.Windows.Forms.TextBox();
            this.patronymicTINLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.userCancelButton = new System.Windows.Forms.Button();
            this.userOkButton = new System.Windows.Forms.Button();
            this.userClearButton = new System.Windows.Forms.Button();
            this.userGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // userGroupBox
            // 
            this.userGroupBox.Controls.Add(this.patronymicTextBox);
            this.userGroupBox.Controls.Add(this.patronymicTINLabel);
            this.userGroupBox.Controls.Add(this.nameTextBox);
            this.userGroupBox.Controls.Add(this.nameLabel);
            this.userGroupBox.Controls.Add(this.surnameTextBox);
            this.userGroupBox.Controls.Add(this.SurnameLabel);
            this.userGroupBox.Location = new System.Drawing.Point(10, 10);
            this.userGroupBox.Name = "userGroupBox";
            this.userGroupBox.Size = new System.Drawing.Size(441, 148);
            this.userGroupBox.TabIndex = 6;
            this.userGroupBox.TabStop = false;
            this.userGroupBox.Text = "Пользователь";
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.Location = new System.Drawing.Point(76, 104);
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.Size = new System.Drawing.Size(343, 20);
            this.patronymicTextBox.TabIndex = 5;
            // 
            // patronymicTINLabel
            // 
            this.patronymicTINLabel.AutoSize = true;
            this.patronymicTINLabel.Location = new System.Drawing.Point(8, 107);
            this.patronymicTINLabel.Name = "patronymicTINLabel";
            this.patronymicTINLabel.Size = new System.Drawing.Size(54, 13);
            this.patronymicTINLabel.TabIndex = 4;
            this.patronymicTINLabel.Text = "Отчество";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(76, 69);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(343, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(33, 72);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Имя";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(76, 30);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(343, 20);
            this.surnameTextBox.TabIndex = 1;
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(6, 37);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(56, 13);
            this.SurnameLabel.TabIndex = 0;
            this.SurnameLabel.Text = "Фамилия";
            // 
            // userCancelButton
            // 
            this.userCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.userCancelButton.Location = new System.Drawing.Point(174, 167);
            this.userCancelButton.Name = "userCancelButton";
            this.userCancelButton.Size = new System.Drawing.Size(75, 23);
            this.userCancelButton.TabIndex = 5;
            this.userCancelButton.Text = "Отмена";
            this.userCancelButton.UseVisualStyleBackColor = true;
            // 
            // userOkButton
            // 
            this.userOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.userOkButton.Location = new System.Drawing.Point(33, 167);
            this.userOkButton.Name = "userOkButton";
            this.userOkButton.Size = new System.Drawing.Size(75, 23);
            this.userOkButton.TabIndex = 4;
            this.userOkButton.Text = "Ok";
            this.userOkButton.UseVisualStyleBackColor = true;
            // 
            // userClearButton
            // 
            this.userClearButton.Location = new System.Drawing.Point(354, 167);
            this.userClearButton.Name = "userClearButton";
            this.userClearButton.Size = new System.Drawing.Size(75, 23);
            this.userClearButton.TabIndex = 7;
            this.userClearButton.Text = "Очистить";
            this.userClearButton.UseVisualStyleBackColor = true;
            this.userClearButton.Click += new System.EventHandler(this.userClearButton_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 202);
            this.Controls.Add(this.userGroupBox);
            this.Controls.Add(this.userCancelButton);
            this.Controls.Add(this.userOkButton);
            this.Controls.Add(this.userClearButton);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.userGroupBox.ResumeLayout(false);
            this.userGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox userGroupBox;
        protected internal System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.Label patronymicTINLabel;
        protected internal System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        protected internal System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.Button userClearButton;
        protected internal System.Windows.Forms.Button userCancelButton;
        protected internal System.Windows.Forms.Button userOkButton;
    }
}
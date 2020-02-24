namespace MCDFiscalManager.WinFormsInterface
{
    partial class UserDataForm
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
            this.components = new System.ComponentModel.Container();
            this.editUserDataButton = new System.Windows.Forms.Button();
            this.addUserDataButton = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // editUserDataButton
            // 
            this.editUserDataButton.Location = new System.Drawing.Point(175, 276);
            this.editUserDataButton.Name = "editUserDataButton";
            this.editUserDataButton.Size = new System.Drawing.Size(104, 23);
            this.editUserDataButton.TabIndex = 7;
            this.editUserDataButton.Text = "Редактировать";
            this.editUserDataButton.UseVisualStyleBackColor = true;
            this.editUserDataButton.Click += new System.EventHandler(this.editUserDataButton_Click);
            // 
            // addUserDataButton
            // 
            this.addUserDataButton.Location = new System.Drawing.Point(93, 277);
            this.addUserDataButton.Name = "addUserDataButton";
            this.addUserDataButton.Size = new System.Drawing.Size(75, 23);
            this.addUserDataButton.TabIndex = 6;
            this.addUserDataButton.Text = "Добавить";
            this.addUserDataButton.UseVisualStyleBackColor = true;
            this.addUserDataButton.Click += new System.EventHandler(this.addUserDataButton_Click);
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(12, 277);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(75, 23);
            this.deleteUserButton.TabIndex = 5;
            this.deleteUserButton.Text = "Удалить";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // userDataGridView
            // 
            this.userDataGridView.AllowUserToAddRows = false;
            this.userDataGridView.AllowUserToDeleteRows = false;
            this.userDataGridView.AllowUserToResizeColumns = false;
            this.userDataGridView.AllowUserToResizeRows = false;
            this.userDataGridView.AutoGenerateColumns = false;
            this.userDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIdDataGridViewTextBoxColumn,
            this.surnameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.patronymicDataGridViewTextBoxColumn});
            this.userDataGridView.DataSource = this.userBindingSource;
            this.userDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.userDataGridView.Location = new System.Drawing.Point(0, 0);
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.ReadOnly = true;
            this.userDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.userDataGridView.Size = new System.Drawing.Size(800, 246);
            this.userDataGridView.TabIndex = 4;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(MCDFiscalManager.BusinessModel.Model.User);
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            this.userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            this.userIdDataGridViewTextBoxColumn.HeaderText = "ID";
            this.userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            this.userIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "Surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            this.surnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patronymicDataGridViewTextBoxColumn
            // 
            this.patronymicDataGridViewTextBoxColumn.DataPropertyName = "Patronymic";
            this.patronymicDataGridViewTextBoxColumn.HeaderText = "Отчество";
            this.patronymicDataGridViewTextBoxColumn.Name = "patronymicDataGridViewTextBoxColumn";
            this.patronymicDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // UserDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 312);
            this.Controls.Add(this.editUserDataButton);
            this.Controls.Add(this.addUserDataButton);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.userDataGridView);
            this.Name = "UserDataForm";
            this.Text = "Пользователи";
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            var topLeftHeaderCell = userDataGridView.TopLeftHeaderCell;
            this.ResumeLayout(false);

        }

        #endregion

        protected internal System.Windows.Forms.Button editUserDataButton;
        protected internal System.Windows.Forms.Button addUserDataButton;
        protected internal System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userBindingSource;
    }
}
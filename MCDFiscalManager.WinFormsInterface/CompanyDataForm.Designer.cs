namespace MCDFiscalManager.WinFormsInterface
{
    partial class CompanyDataForm
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
            this.companyDataGridView = new System.Windows.Forms.DataGridView();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deleteCompanyButton = new System.Windows.Forms.Button();
            this.addCompanyDataButton = new System.Windows.Forms.Button();
            this.editCompanyDataButton = new System.Windows.Forms.Button();
            this.CompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legalFormDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // companyDataGridView
            // 
            this.companyDataGridView.AllowUserToAddRows = false;
            this.companyDataGridView.AllowUserToDeleteRows = false;
            this.companyDataGridView.AllowUserToResizeColumns = false;
            this.companyDataGridView.AllowUserToResizeRows = false;
            this.companyDataGridView.AutoGenerateColumns = false;
            this.companyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.companyDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.companyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyId,
            this.fullNameDataGridViewTextBoxColumn,
            this.shortNameDataGridViewTextBoxColumn,
            this.legalFormDataGridViewTextBoxColumn,
            this.tINDataGridViewTextBoxColumn});
            this.companyDataGridView.DataSource = this.companyBindingSource;
            this.companyDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.companyDataGridView.Location = new System.Drawing.Point(0, 0);
            this.companyDataGridView.Name = "companyDataGridView";
            this.companyDataGridView.ReadOnly = true;
            this.companyDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.companyDataGridView.Size = new System.Drawing.Size(800, 246);
            this.companyDataGridView.TabIndex = 0;
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(MCDFiscalManager.BusinessModel.Model.Company);
            // 
            // deleteCompanyButton
            // 
            this.deleteCompanyButton.Location = new System.Drawing.Point(12, 265);
            this.deleteCompanyButton.Name = "deleteCompanyButton";
            this.deleteCompanyButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCompanyButton.TabIndex = 1;
            this.deleteCompanyButton.Text = "Удалить";
            this.deleteCompanyButton.UseVisualStyleBackColor = true;
            this.deleteCompanyButton.Click += new System.EventHandler(this.deleteCompanyButton_Click);
            // 
            // addCompanyDataButton
            // 
            this.addCompanyDataButton.Location = new System.Drawing.Point(93, 265);
            this.addCompanyDataButton.Name = "addCompanyDataButton";
            this.addCompanyDataButton.Size = new System.Drawing.Size(75, 23);
            this.addCompanyDataButton.TabIndex = 2;
            this.addCompanyDataButton.Text = "Добавить";
            this.addCompanyDataButton.UseVisualStyleBackColor = true;
            this.addCompanyDataButton.Click += new System.EventHandler(this.addCompanyDataButton_Click);
            // 
            // editCompanyDataButton
            // 
            this.editCompanyDataButton.Location = new System.Drawing.Point(175, 264);
            this.editCompanyDataButton.Name = "editCompanyDataButton";
            this.editCompanyDataButton.Size = new System.Drawing.Size(104, 23);
            this.editCompanyDataButton.TabIndex = 3;
            this.editCompanyDataButton.Text = "Редактировать";
            this.editCompanyDataButton.UseVisualStyleBackColor = true;
            this.editCompanyDataButton.Click += new System.EventHandler(this.editCompanyDataButton_Click);
            // 
            // CompanyId
            // 
            this.CompanyId.DataPropertyName = "CompanyId";
            this.CompanyId.HeaderText = "ID";
            this.CompanyId.Name = "CompanyId";
            this.CompanyId.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Полное наименование";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shortNameDataGridViewTextBoxColumn
            // 
            this.shortNameDataGridViewTextBoxColumn.DataPropertyName = "ShortName";
            this.shortNameDataGridViewTextBoxColumn.HeaderText = "Сокращенное наименование";
            this.shortNameDataGridViewTextBoxColumn.Name = "shortNameDataGridViewTextBoxColumn";
            this.shortNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // legalFormDataGridViewTextBoxColumn
            // 
            this.legalFormDataGridViewTextBoxColumn.DataPropertyName = "LegalForm";
            this.legalFormDataGridViewTextBoxColumn.HeaderText = "Форма организации";
            this.legalFormDataGridViewTextBoxColumn.Name = "legalFormDataGridViewTextBoxColumn";
            this.legalFormDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tINDataGridViewTextBoxColumn
            // 
            this.tINDataGridViewTextBoxColumn.DataPropertyName = "TIN";
            this.tINDataGridViewTextBoxColumn.HeaderText = "ИНН";
            this.tINDataGridViewTextBoxColumn.Name = "tINDataGridViewTextBoxColumn";
            this.tINDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CompanyDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 312);
            this.Controls.Add(this.editCompanyDataButton);
            this.Controls.Add(this.addCompanyDataButton);
            this.Controls.Add(this.deleteCompanyButton);
            this.Controls.Add(this.companyDataGridView);
            this.Name = "CompanyDataForm";
            this.Text = "Компании";
            ((System.ComponentModel.ISupportInitialize)(this.companyDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            var topLeftHeaderCell = companyDataGridView.TopLeftHeaderCell;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView companyDataGridView;
        private System.Windows.Forms.BindingSource companyBindingSource;
        protected internal System.Windows.Forms.Button deleteCompanyButton;
        protected internal System.Windows.Forms.Button addCompanyDataButton;
        protected internal System.Windows.Forms.Button editCompanyDataButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn legalFormDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tINDataGridViewTextBoxColumn;
    }
}
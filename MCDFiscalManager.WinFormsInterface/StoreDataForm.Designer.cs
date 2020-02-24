namespace MCDFiscalManager.WinFormsInterface
{
    partial class StoreDataForm
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
            this.storeDataGridView = new System.Windows.Forms.DataGridView();
            this.editStoreDataButton = new System.Windows.Forms.Button();
            this.addStoreDataButton = new System.Windows.Forms.Button();
            this.deleteStoreButton = new System.Windows.Forms.Button();
            this.storeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.storeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRRCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxAuthoritiesCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.storeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // storeDataGridView
            // 
            this.storeDataGridView.AllowUserToAddRows = false;
            this.storeDataGridView.AllowUserToDeleteRows = false;
            this.storeDataGridView.AllowUserToResizeColumns = false;
            this.storeDataGridView.AllowUserToResizeRows = false;
            this.storeDataGridView.AutoGenerateColumns = false;
            this.storeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.storeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.storeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.storeIdDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.ownerDataGridViewTextBoxColumn,
            this.tRRCDataGridViewTextBoxColumn,
            this.taxAuthoritiesCodeDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn});
            this.storeDataGridView.DataSource = this.storeBindingSource;
            this.storeDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.storeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.storeDataGridView.Name = "storeDataGridView";
            this.storeDataGridView.ReadOnly = true;
            this.storeDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.storeDataGridView.Size = new System.Drawing.Size(1084, 246);
            this.storeDataGridView.TabIndex = 4;
            // 
            // editStoreDataButton
            // 
            this.editStoreDataButton.Location = new System.Drawing.Point(175, 345);
            this.editStoreDataButton.Name = "editStoreDataButton";
            this.editStoreDataButton.Size = new System.Drawing.Size(104, 23);
            this.editStoreDataButton.TabIndex = 7;
            this.editStoreDataButton.Text = "Редактировать";
            this.editStoreDataButton.UseVisualStyleBackColor = true;
            this.editStoreDataButton.Click += new System.EventHandler(this.editStoreDataButton_Click);
            // 
            // addStoreDataButton
            // 
            this.addStoreDataButton.Location = new System.Drawing.Point(93, 346);
            this.addStoreDataButton.Name = "addStoreDataButton";
            this.addStoreDataButton.Size = new System.Drawing.Size(75, 23);
            this.addStoreDataButton.TabIndex = 6;
            this.addStoreDataButton.Text = "Добавить";
            this.addStoreDataButton.UseVisualStyleBackColor = true;
            this.addStoreDataButton.Click += new System.EventHandler(this.addStoreDataButton_Click);
            // 
            // deleteStoreButton
            // 
            this.deleteStoreButton.Location = new System.Drawing.Point(12, 346);
            this.deleteStoreButton.Name = "deleteStoreButton";
            this.deleteStoreButton.Size = new System.Drawing.Size(75, 23);
            this.deleteStoreButton.TabIndex = 5;
            this.deleteStoreButton.Text = "Удалить";
            this.deleteStoreButton.UseVisualStyleBackColor = true;
            this.deleteStoreButton.Click += new System.EventHandler(this.deleteStoreButton_Click);
            // 
            // storeBindingSource
            // 
            this.storeBindingSource.DataSource = typeof(MCDFiscalManager.BusinessModel.Model.Store);
            // 
            // storeIdDataGridViewTextBoxColumn
            // 
            this.storeIdDataGridViewTextBoxColumn.DataPropertyName = "StoreId";
            this.storeIdDataGridViewTextBoxColumn.HeaderText = "ID";
            this.storeIdDataGridViewTextBoxColumn.Name = "storeIdDataGridViewTextBoxColumn";
            this.storeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ownerDataGridViewTextBoxColumn
            // 
            this.ownerDataGridViewTextBoxColumn.DataPropertyName = "Owner";
            this.ownerDataGridViewTextBoxColumn.HeaderText = "Компания";
            this.ownerDataGridViewTextBoxColumn.Name = "ownerDataGridViewTextBoxColumn";
            this.ownerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tRRCDataGridViewTextBoxColumn
            // 
            this.tRRCDataGridViewTextBoxColumn.DataPropertyName = "TRRC";
            this.tRRCDataGridViewTextBoxColumn.HeaderText = "КПП";
            this.tRRCDataGridViewTextBoxColumn.Name = "tRRCDataGridViewTextBoxColumn";
            this.tRRCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taxAuthoritiesCodeDataGridViewTextBoxColumn
            // 
            this.taxAuthoritiesCodeDataGridViewTextBoxColumn.DataPropertyName = "TaxAuthoritiesCode";
            this.taxAuthoritiesCodeDataGridViewTextBoxColumn.HeaderText = "Код НИ";
            this.taxAuthoritiesCodeDataGridViewTextBoxColumn.Name = "taxAuthoritiesCodeDataGridViewTextBoxColumn";
            this.taxAuthoritiesCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Адресс";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StoreDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 450);
            this.Controls.Add(this.storeDataGridView);
            this.Controls.Add(this.editStoreDataButton);
            this.Controls.Add(this.addStoreDataButton);
            this.Controls.Add(this.deleteStoreButton);
            this.Name = "StoreDataForm";
            this.Text = "StoreDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.storeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView storeDataGridView;
        protected internal System.Windows.Forms.Button editStoreDataButton;
        protected internal System.Windows.Forms.Button addStoreDataButton;
        protected internal System.Windows.Forms.Button deleteStoreButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRRCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxAuthoritiesCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource storeBindingSource;
    }
}
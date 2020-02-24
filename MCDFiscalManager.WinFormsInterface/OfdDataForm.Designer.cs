namespace MCDFiscalManager.WinFormsInterface
{
    partial class OfdDataForm
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
            this.editOfdDataButton = new System.Windows.Forms.Button();
            this.addOfdDataButton = new System.Windows.Forms.Button();
            this.deleteOfdButton = new System.Windows.Forms.Button();
            this.ofdDataGridView = new System.Windows.Forms.DataGridView();
            this.oFDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oFDIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ofdDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oFDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // editOfdDataButton
            // 
            this.editOfdDataButton.Location = new System.Drawing.Point(175, 282);
            this.editOfdDataButton.Name = "editOfdDataButton";
            this.editOfdDataButton.Size = new System.Drawing.Size(104, 23);
            this.editOfdDataButton.TabIndex = 11;
            this.editOfdDataButton.Text = "Редактировать";
            this.editOfdDataButton.UseVisualStyleBackColor = true;
            this.editOfdDataButton.Click += new System.EventHandler(this.editOfdDataButton_Click);
            // 
            // addOfdDataButton
            // 
            this.addOfdDataButton.Location = new System.Drawing.Point(93, 283);
            this.addOfdDataButton.Name = "addOfdDataButton";
            this.addOfdDataButton.Size = new System.Drawing.Size(75, 23);
            this.addOfdDataButton.TabIndex = 10;
            this.addOfdDataButton.Text = "Добавить";
            this.addOfdDataButton.UseVisualStyleBackColor = true;
            this.addOfdDataButton.Click += new System.EventHandler(this.addOfdDataButton_Click);
            // 
            // deleteOfdButton
            // 
            this.deleteOfdButton.Location = new System.Drawing.Point(12, 283);
            this.deleteOfdButton.Name = "deleteOfdButton";
            this.deleteOfdButton.Size = new System.Drawing.Size(75, 23);
            this.deleteOfdButton.TabIndex = 9;
            this.deleteOfdButton.Text = "Удалить";
            this.deleteOfdButton.UseVisualStyleBackColor = true;
            this.deleteOfdButton.Click += new System.EventHandler(this.deleteOfdButton_Click);
            // 
            // ofdDataGridView
            // 
            this.ofdDataGridView.AllowUserToAddRows = false;
            this.ofdDataGridView.AllowUserToDeleteRows = false;
            this.ofdDataGridView.AllowUserToResizeColumns = false;
            this.ofdDataGridView.AllowUserToResizeRows = false;
            this.ofdDataGridView.AutoGenerateColumns = false;
            this.ofdDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ofdDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.ofdDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ofdDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oFDIdDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.tINDataGridViewTextBoxColumn});
            this.ofdDataGridView.DataSource = this.oFDBindingSource;
            this.ofdDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.ofdDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ofdDataGridView.Name = "ofdDataGridView";
            this.ofdDataGridView.ReadOnly = true;
            this.ofdDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ofdDataGridView.Size = new System.Drawing.Size(800, 246);
            this.ofdDataGridView.TabIndex = 8;
            // 
            // oFDBindingSource
            // 
            this.oFDBindingSource.DataSource = typeof(MCDFiscalManager.BusinessModel.Model.OFD);
            // 
            // oFDIdDataGridViewTextBoxColumn
            // 
            this.oFDIdDataGridViewTextBoxColumn.DataPropertyName = "OFDId";
            this.oFDIdDataGridViewTextBoxColumn.HeaderText = "ID";
            this.oFDIdDataGridViewTextBoxColumn.Name = "oFDIdDataGridViewTextBoxColumn";
            this.oFDIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Полное наименование";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tINDataGridViewTextBoxColumn
            // 
            this.tINDataGridViewTextBoxColumn.DataPropertyName = "TIN";
            this.tINDataGridViewTextBoxColumn.HeaderText = "ИНН";
            this.tINDataGridViewTextBoxColumn.Name = "tINDataGridViewTextBoxColumn";
            this.tINDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // OfdDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 312);
            this.Controls.Add(this.editOfdDataButton);
            this.Controls.Add(this.addOfdDataButton);
            this.Controls.Add(this.deleteOfdButton);
            this.Controls.Add(this.ofdDataGridView);
            this.Name = "OfdDataForm";
            this.Text = "ОФД";
            ((System.ComponentModel.ISupportInitialize)(this.ofdDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oFDBindingSource)).EndInit();
            var topLeftHeaderCell = ofdDataGridView.TopLeftHeaderCell;
            this.ResumeLayout(false);

        }

        #endregion

        protected internal System.Windows.Forms.Button editOfdDataButton;
        protected internal System.Windows.Forms.Button addOfdDataButton;
        protected internal System.Windows.Forms.Button deleteOfdButton;
        private System.Windows.Forms.DataGridView ofdDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn oFDIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tINDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource oFDBindingSource;
    }
}
namespace MCDFiscalManager.WinFormsInterface
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компанииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оФДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пБОToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фискальныеРегистраторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеToolStripMenuItem,
            this.действияToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компанииToolStripMenuItem,
            this.пользователиToolStripMenuItem,
            this.оФДToolStripMenuItem,
            this.пБОToolStripMenuItem,
            this.фискальныеРегистраторыToolStripMenuItem});
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            this.данныеToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.данныеToolStripMenuItem.Text = "Данные";
            // 
            // компанииToolStripMenuItem
            // 
            this.компанииToolStripMenuItem.Name = "компанииToolStripMenuItem";
            this.компанииToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.компанииToolStripMenuItem.Text = "Компании";
            this.компанииToolStripMenuItem.Click += new System.EventHandler(this.компанииToolStripMenuItem_Click);
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            this.пользователиToolStripMenuItem.Click += new System.EventHandler(this.пользователиToolStripMenuItem_Click);
            // 
            // оФДToolStripMenuItem
            // 
            this.оФДToolStripMenuItem.Name = "оФДToolStripMenuItem";
            this.оФДToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.оФДToolStripMenuItem.Text = "ОФД";
            this.оФДToolStripMenuItem.Click += new System.EventHandler(this.оФДToolStripMenuItem_Click);
            // 
            // пБОToolStripMenuItem
            // 
            this.пБОToolStripMenuItem.Name = "пБОToolStripMenuItem";
            this.пБОToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.пБОToolStripMenuItem.Text = "ПБО";
            this.пБОToolStripMenuItem.Click += new System.EventHandler(this.пБОToolStripMenuItem_Click);
            // 
            // фискальныеРегистраторыToolStripMenuItem
            // 
            this.фискальныеРегистраторыToolStripMenuItem.Name = "фискальныеРегистраторыToolStripMenuItem";
            this.фискальныеРегистраторыToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.фискальныеРегистраторыToolStripMenuItem.Text = "Фискальные регистраторы";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "McDonald\'s Fiscal Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компанииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оФДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пБОToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фискальныеРегистраторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
    }
}
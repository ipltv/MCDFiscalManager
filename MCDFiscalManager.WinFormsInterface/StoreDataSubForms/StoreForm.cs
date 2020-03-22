using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MCDFiscalManager.WinFormsInterface.StoreDataSubForms
{
    public partial class StoreForm : Form
    {
        public StoreForm()
        {
            InitializeComponent();
        }

        private void storeClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                    (item as TextBox).Text = string.Empty;
            }
        }

        private void storeOkButton_Click(object sender, EventArgs e)
        {

        }
    }
}

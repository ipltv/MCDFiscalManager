﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCDFiscalManager.WinFormsInterface.OfdDataSubForms
{
    public partial class OfdForm : Form
    {
        public OfdForm()
        {
            InitializeComponent();
        }

        private void ofdClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                    (item as TextBox).Text = string.Empty;
            }
        }
    }
}

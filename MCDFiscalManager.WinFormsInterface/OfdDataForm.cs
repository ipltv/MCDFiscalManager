using MCDFiscalManager.BusinessModel.Model;
using MCDFiscalManager.DataController;
using MCDFiscalManager.WinFormsInterface.OfdDataSubForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCDFiscalManager.WinFormsInterface
{
    public partial class OfdDataForm : Form
    {
        OFDDataController controller;
        public OfdDataForm()
        {
            InitializeComponent();
        }
        public OfdDataForm(OFDDataController ofdController)
        {
            controller = ofdController ?? throw new ArgumentNullException(nameof(ofdController), Messages.ControllerNullExceptionMessage);
            InitializeComponent();
            ofdDataGridView.DataSource = controller.Elements ?? throw new ArgumentNullException(nameof(ofdController), Messages.ControllerCollectionNullExceptionMessage);
        }

        private void addOfdDataButton_Click(object sender, EventArgs e)
        {
            OfdForm ofdAddForm = new OfdForm();
            DialogResult dialogResult = ofdAddForm.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;

            var newOfd = new OFD(ofdAddForm.tinTextBox.Text,
                                         ofdAddForm.fullNameTextBox.Text);
            controller.AddElement(newOfd);
            ofdDataGridView.DataSource = controller.Elements;
        }

        private void deleteOfdButton_Click(object sender, EventArgs e)
        {
            if (ofdDataGridView.SelectedRows.Count > 0)
            {
                int index = ofdDataGridView.SelectedRows[0].Index;
                int id;
                bool converted = int.TryParse(ofdDataGridView[0, index].Value.ToString(), out id);
                if (!converted) return;

                var element = from t in controller.Elements where t.ID == id select t;
                controller.RemoveElement(element.First());
                ofdDataGridView.DataSource = controller.Elements;
            }
        }

        private void editOfdDataButton_Click(object sender, EventArgs e)
        {
            if (ofdDataGridView.SelectedRows.Count > 0)
            {
                int index = ofdDataGridView.SelectedRows[0].Index;
                int id;
                bool converted = int.TryParse(ofdDataGridView[0, index].Value.ToString(), out id);
                if (!converted) return;

                var ofds = from t in controller.Elements where t.ID == id select t;
                OFD ofd = ofds.First();

                OfdForm ofdForm = new OfdForm();
                ofdForm.fullNameTextBox.Text = ofd.FullName;
                ofdForm.tinTextBox.Text = ofd.TIN;

                DialogResult dialogResult = ofdForm.ShowDialog(this);

                if (dialogResult == DialogResult.Cancel) return;

                ofd.FullName = ofdForm.fullNameTextBox.Text;
                ofd.TIN = ofdForm.tinTextBox.Text;
                
                controller.UpdateElement(ofd);
                ofdDataGridView.DataSource = controller.Elements;
            }
        }
    }
}

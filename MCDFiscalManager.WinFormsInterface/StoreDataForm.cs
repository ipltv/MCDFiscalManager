using MCDFiscalManager.BusinessModel.Model;
using MCDFiscalManager.DataController;
using MCDFiscalManager.WinFormsInterface.StoreDataSubForms;
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
    public partial class StoreDataForm : Form
    {
        StoreDataController controller;
        CompanyDataController companyDataController;
        public StoreDataForm()
        {
            InitializeComponent();
        }

        public StoreDataForm(StoreDataController storeController, CompanyDataController companyController)
        {
            controller = storeController ?? throw new ArgumentNullException(nameof(storeController), Messages.ControllerNullExceptionMessage);
            companyDataController = companyController ?? throw new ArgumentNullException(nameof(companyController), Messages.ControllerNullExceptionMessage);
            InitializeComponent();
            storeDataGridView.DataSource = controller.Elements ?? throw new ArgumentNullException(nameof(storeController), Messages.ControllerCollectionNullExceptionMessage);
        }

        private void deleteStoreButton_Click(object sender, EventArgs e)
        {

        }

        private void addStoreDataButton_Click(object sender, EventArgs e)
        {
            StoreForm storeAddForm = new StoreForm();
            storeAddForm.ownerComboBox.Items.AddRange(companyDataController.Elements.ToArray());
            storeAddForm.ownerComboBox.SelectedItem = storeAddForm.ownerComboBox.Items[0];
            DialogResult dialogResult = storeAddForm.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;

            var address = new Address(storeAddForm.codeOfRegionTextBox.Text,
                                      storeAddForm.postcodeTextBox.Text,
                                      storeAddForm.districtTextBox.Text,
                                      storeAddForm.cityTextBox.Text,
                                      storeAddForm.localityTextBox.Text,
                                      storeAddForm.streetTextBox.Text,
                                      storeAddForm.houseTextBox.Text,
                                      storeAddForm.buildingTextBox.Text,
                                      storeAddForm.flatTextBox.Text);

            var newStore = new Store(storeAddForm.numberTextBox.Text,
                                     storeAddForm.nameTextBox.Text,
                                     (Company)storeAddForm.ownerComboBox.SelectedItem,
                                     storeAddForm.trrcTextBox.Text,
                                     storeAddForm.taxCodeTextBox.Text,
                                     address);

            controller.AddElement(newStore);
            newStore.StoreId = controller.Elements.Max(t => t.StoreId) + 1;
            storeDataGridView.DataSource = controller.Elements;
        }

        private void editStoreDataButton_Click(object sender, EventArgs e)
        {

        }
    }
}

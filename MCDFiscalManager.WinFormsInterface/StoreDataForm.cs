using MCDFiscalManager.BusinessModel.Model;
using MCDFiscalManager.DataController;
using MCDFiscalManager.WinFormsInterface.StoreDataSubForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            if (storeDataGridView.SelectedRows.Count > 0)
            {
                int index = storeDataGridView.SelectedRows[0].Index;
                int id;
                bool converted = int.TryParse(storeDataGridView[0, index].Value.ToString(), out id);
                if (!converted) return;

                var element = from t in controller.Elements where t.ID == id select t;
                controller.RemoveElement(element.First());

                storeDataGridView.DataSource = controller.Elements;
            }
        }

        private void addStoreDataButton_Click(object sender, EventArgs e)
        {
            StoreForm storeAddForm = new StoreForm();
            storeAddForm.ownerComboBox.Items.AddRange(companyDataController.Elements.ToArray());
            storeAddForm.ownerComboBox.SelectedItem = storeAddForm.ownerComboBox.Items[0];
            DialogResult dialogResult = storeAddForm.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;
            if (!(Regex.IsMatch(storeAddForm.codeOfRegionTextBox.Text, @"^[0-9]{2}$") && storeAddForm.codeOfRegionTextBox.Text.Length == 2))
            {
                MessageBox.Show(Messages.AddressCodeOfRegionFormatError);
                return;
            }
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
            storeDataGridView.DataSource = controller.Elements;
        }

        private void editStoreDataButton_Click(object sender, EventArgs e)
        {
            if (storeDataGridView.SelectedRows.Count > 0)
            {
                int index = storeDataGridView.SelectedRows[0].Index;
                int number;
                bool converted = int.TryParse(storeDataGridView[0, index].Value.ToString(), out number);
                if (!converted) return;

                var stores = from t in controller.Elements where int.Parse(t.Number) == number select t;
                Store store = stores.First();

                StoreForm storeAddForm = new StoreForm();
                storeAddForm.numberTextBox.Text = store.Number;
                storeAddForm.nameTextBox.Text = store.Name;
                storeAddForm.ownerComboBox.Items.AddRange(companyDataController.Elements.ToArray());
                storeAddForm.ownerComboBox.SelectedItem = store.Owner;
                storeAddForm.trrcTextBox.Text = store.TRRC;
                storeAddForm.taxCodeTextBox.Text = store.TaxAuthoritiesCode;

                storeAddForm.codeOfRegionTextBox.Text = store.Address.CodeOfRegion;
                storeAddForm.postcodeTextBox.Text = store.Address.Postcode;
                storeAddForm.districtTextBox.Text = store.Address.District;
                storeAddForm.cityTextBox.Text = store.Address.City;
                storeAddForm.localityTextBox.Text = store.Address.Locality;
                storeAddForm.streetTextBox.Text = store.Address.Street;
                storeAddForm.houseTextBox.Text = store.Address.House;
                storeAddForm.buildingTextBox.Text = store.Address.Building;
                storeAddForm.flatTextBox.Text = store.Address.Flat;

                DialogResult dialogResult = storeAddForm.ShowDialog(this);

                if (dialogResult == DialogResult.Cancel) return;

                store.Number = storeAddForm.numberTextBox.Text;
                store.Name = storeAddForm.nameTextBox.Text;
                store.Owner = companyDataController.Elements.First(item => item.TIN == ((Company)(storeAddForm.ownerComboBox?.SelectedItem)).TIN);
                store.TRRC = storeAddForm.trrcTextBox.Text;
                store.TaxAuthoritiesCode = storeAddForm.taxCodeTextBox.Text;

                store.Address.CodeOfRegion = storeAddForm.codeOfRegionTextBox.Text;
                store.Address.Postcode = storeAddForm.postcodeTextBox.Text;
                store.Address.District = storeAddForm.districtTextBox.Text;
                store.Address.City = storeAddForm.cityTextBox.Text;
                store.Address.Locality = storeAddForm.localityTextBox.Text;
                store.Address.Street = storeAddForm.streetTextBox.Text;
                store.Address.House = storeAddForm.houseTextBox.Text;
                store.Address.Building = storeAddForm.buildingTextBox.Text;
                store.Address.Flat = storeAddForm.flatTextBox.Text;

                controller.UpdateElement(store);
                storeDataGridView.DataSource = controller.Elements;
            }
        }
    }
}

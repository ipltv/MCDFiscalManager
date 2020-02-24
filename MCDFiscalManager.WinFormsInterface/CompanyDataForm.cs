using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MCDFiscalManager.BusinessModel.Model;
using MCDFiscalManager.DataController;
using MCDFiscalManager.WinFormsInterface.CompanyDataSubForms;

namespace MCDFiscalManager.WinFormsInterface
{
    public partial class CompanyDataForm : Form
    {
        private readonly CompanyDataController controller;
        public CompanyDataForm()
        {
            InitializeComponent();
        }

        public CompanyDataForm(CompanyDataController companyController)
        {
            controller = companyController ?? throw new ArgumentNullException(nameof(companyController), Messages.ControllerNullExceptionMessage);
            InitializeComponent();
            companyDataGridView.DataSource = controller.Elements ?? throw new ArgumentNullException(nameof(companyController),Messages.ControllerCollectionNullExceptionMessage);
        }

        private void addCompanyDataButton_Click(object sender, EventArgs e)
        {
            CompanyForm companyAddForm = new CompanyForm();
            DialogResult dialogResult = companyAddForm.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;

            var newCompany = new Company(companyAddForm.companyFullNameTextBox.Text,
                                         companyAddForm.companyShortNameTextBox.Text,
                                         companyAddForm.companyTINTextBox.Text);
            controller.AddElement(newCompany);
            newCompany.CompanyId = controller.Elements.Max(t => t.CompanyId) + 1;
            companyDataGridView.DataSource = controller.Elements;
        }

        private void deleteCompanyButton_Click(object sender, EventArgs e)
        {
            if(companyDataGridView.SelectedRows.Count > 0)
            {
                int index = companyDataGridView.SelectedRows[0].Index;
                int id;
                bool converted = int.TryParse(companyDataGridView[0, index].Value.ToString(), out id);
                if (!converted) return;

                for(int i = 0; i < controller.Elements.Count; i++)
                {
                    if (controller.Elements[i].CompanyId == id)
                    {
                        controller.RemoveElement(controller.Elements[i]);
                        i--;
                    }
                }
                companyDataGridView.DataSource = controller.Elements;
            }
        }

        private void editCompanyDataButton_Click(object sender, EventArgs e)
        {
            if (companyDataGridView.SelectedRows.Count > 0)
            {
                int index = companyDataGridView.SelectedRows[0].Index;
                int id;
                bool converted = int.TryParse(companyDataGridView[0, index].Value.ToString(), out id);
                if (!converted) return;

                var companies = from t in controller.Elements where t.CompanyId == id select t;
                Company company = companies.First();

                CompanyForm companyAddForm = new CompanyForm();
                companyAddForm.companyFullNameTextBox.Text = company.FullName;
                companyAddForm.companyShortNameTextBox.Text = company.ShortName;
                companyAddForm.companyTINTextBox.Text = company.TIN;

                DialogResult dialogResult = companyAddForm.ShowDialog(this);

                if (dialogResult == DialogResult.Cancel) return;

                company.FullName = companyAddForm.companyFullNameTextBox.Text;
                company.ShortName = companyAddForm.companyShortNameTextBox.Text;
                company.TIN = companyAddForm.companyTINTextBox.Text;
                
                companyDataGridView.DataSource = controller.Elements;
            }
        }
    }
}

using System;
using System.Windows.Forms;
using MCDFiscalManager.DataController;
using MCDFiscalManager.DataController.Savers;
using System.IO;

namespace MCDFiscalManager.WinFormsInterface
{
    public partial class MainForm : Form
    {
        #region Fields
        CompanyDataController companyController;
        UserDataController userController;
        OFDDataController ofdController;
        StoreDataController storeController;
        IDataSaver saver; 
        #endregion

        public MainForm()
        {
            InitializeComponent();
            DirectoryCheck();
            saver = new BinnarySaver();
            companyController = new CompanyDataController(saver);
            userController = new UserDataController(saver);
            ofdController = new OFDDataController(saver);
            storeController = new StoreDataController(saver);
        }

        private void компанииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyDataForm companyDataForm = new CompanyDataForm(companyController);
            companyDataForm.Show(this);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saver.Save(companyController.Elements);
            saver.Save(userController.Elements);
        }

        private void DirectoryCheck()
        {
            DirectoryInfo dataDirectory = new DirectoryInfo(Path.Combine(Application.StartupPath, "data"));
            if (!dataDirectory.Exists) dataDirectory.Create();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDataForm userDataForm = new UserDataForm(userController);
            userDataForm.Show(this);
        }

        private void оФДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OfdDataForm ofdDataForm = new OfdDataForm(ofdController);
            ofdDataForm.Show(this);
        }

        private void пБОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoreDataForm storeDataForm = new StoreDataForm(storeController, companyController);
            storeDataForm.Show(this);
        }
    }
}

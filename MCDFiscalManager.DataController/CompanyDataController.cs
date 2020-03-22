using MCDFiscalManager.BusinessModel.Model;

namespace MCDFiscalManager.DataController
{
    public class CompanyDataController : AuxiliaryDataController<Company>
    {
        public CompanyDataController() { } 

        public CompanyDataController(IDataSaver saver) : base(saver) { }

    }
}

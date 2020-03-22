using MCDFiscalManager.BusinessModel.Model;

namespace MCDFiscalManager.DataController
{
    public class FiscalDataController : AuxiliaryDataController<FiscalPrinter>
    {
        public FiscalDataController() { }
        public FiscalDataController (IDataSaver saver) : base(saver) {}
    }
}

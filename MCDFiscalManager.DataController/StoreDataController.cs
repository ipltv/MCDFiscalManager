using MCDFiscalManager.BusinessModel.Model;

namespace MCDFiscalManager.DataController
{
    public class StoreDataController : AuxiliaryDataController<Store>
    {
        public StoreDataController() { }

        public StoreDataController(IDataSaver saver) : base(saver) { }

    }
}

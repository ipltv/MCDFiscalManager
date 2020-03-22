using MCDFiscalManager.BusinessModel.Model;

namespace MCDFiscalManager.DataController
{
    public class OFDDataController : AuxiliaryDataController<OFD>
    {
        public OFDDataController() { }
        public OFDDataController(IDataSaver saver) : base(saver) { }
    }
}

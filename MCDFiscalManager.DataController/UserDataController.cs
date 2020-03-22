using MCDFiscalManager.BusinessModel.Model;
namespace MCDFiscalManager.DataController
{
    public class UserDataController : AuxiliaryDataController<User>
    {
        public UserDataController() { }
        public UserDataController(IDataSaver saver) : base(saver) { }
    }
}

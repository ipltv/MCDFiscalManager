using MCDFiscalManager.BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.DataController
{
    public class StoreDataController : AuxiliaryDataController<Store>
    {
        public StoreDataController() { }

        public StoreDataController(Store newStore) : base(newStore) { }

        public StoreDataController(IDataSaver saver) : base(saver) { }

        public override bool SetCurrentElement(string value)
        {
            Store result = Elements.FirstOrDefault(t => t.Number == value);
            if (result != null)
            {
                curentElement = result;
                return true;
            }
            else { return false; }
        }
    }
}

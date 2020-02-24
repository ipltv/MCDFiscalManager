using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCDFiscalManager.BusinessModel.Model;
using System.Runtime.Serialization;
using System.IO;

namespace MCDFiscalManager.DataController
{
    public class OFDDataController : AuxiliaryDataController<OFD>
    {
        public OFDDataController() { }
        public OFDDataController(OFD ofd) : base(ofd) { }
        public OFDDataController(IDataSaver saver) : base(saver) { }
        public override bool SetCurrentElement(string tin)
        {
            OFD ofdByTIN = Elements.FirstOrDefault(p => p.TIN == tin);
            if (ofdByTIN != null)
            {
                curentElement = ofdByTIN;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

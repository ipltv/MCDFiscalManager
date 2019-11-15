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
        public OFDDataController(IFormatter formatter, FileInfo ofdDataFile) : base(formatter, ofdDataFile) { }
        public OFDDataController(OFD ofd) : base(ofd.TIN, ofd) { }
        public override OFD this[string value]
        {
            get
            {
                OFD result;
                elements.TryGetValue(value, out result);
                return result;
            }
        }

        public override bool SetCurrentElement(string tin)
        {
            OFD ofdByTIN = elements.Values.FirstOrDefault(p => p.TIN == tin);
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

        public override void AddElement(OFD element)
        {
            elements.Add(element.TIN, element);
        }

        public override void RemoveElement(OFD element)
        {
            OFD deletedOFD = elements[element.TIN];
            elements.Remove(deletedOFD.TIN);

            if (curentElement == deletedOFD)
            {
                curentElement = elements.Values.FirstOrDefault(p => p != null);
            }
        }
    }
}

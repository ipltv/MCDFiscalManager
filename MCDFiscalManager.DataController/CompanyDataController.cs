using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCDFiscalManager.BusinessModel.Model;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MCDFiscalManager.DataController
{
    public class CompanyDataController : AuxiliaryDataController<Company>
    {
        public CompanyDataController() { } 

        public CompanyDataController(Company newCompany) : base(newCompany) { }

        public override bool SetCurrentElement(string TIN)
        {
            Company result = Elements.FirstOrDefault(t => t.TIN == TIN);
            if (result != null)
            {
                curentElement = result;
                return true;
            }
            else { return false; }
        }

    }
}

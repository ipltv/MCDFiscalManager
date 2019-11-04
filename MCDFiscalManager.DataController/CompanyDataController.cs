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
        public CompanyDataController(BinaryFormatter formatter, FileInfo companyDataFile) : base(formatter, companyDataFile) { }
        public CompanyDataController(Company newCompany) : base(newCompany.TIN, newCompany) { }
        public override Company this[string value]
        {
            get
            {
                Company result;
                elements.TryGetValue(value, out result);
                return result;
            }
        }
        public override bool SetCurrentElement(string value)
        {
            Company result = elements.Values.FirstOrDefault(p => p.TIN == value);
            if (result != null)
            {
                curentElement = result;
                return true;
            }
            else { return false; }
        }

        public override void AddElement(Company element)
        {
            throw new NotImplementedException();
        }

        public override void RemoveElement(Company element)
        {
            throw new NotImplementedException();
        }
    }
}

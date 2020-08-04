using MCDFiscalManager.BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataMovementLayer
{
    class ExcelDataProvider : IDataProvider
    {
        public IList<T> Load<T>(string connectionString)
        {
            if (typeof(T) == typeof(OFD)) return LoadOfdData().Cast<T>().ToList();
            if (typeof(T) == typeof(Company)) return LoadCompanyData().Cast<T>().ToList();
            return null;
        }

        private IList<object> LoadCompanyData()
        {
            throw new NotImplementedException();
        }

        private IList<OFD> LoadOfdData()
        {
            throw new NotImplementedException();
        }

        public void Save<T>()
        {
            throw new NotImplementedException();
        }
    }
}

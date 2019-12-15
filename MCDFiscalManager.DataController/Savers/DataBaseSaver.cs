using MCDFiscalManager.DataController.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.DataController.Savers
{
    public class DataBaseSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using(FiscalContext fiscalContext = new FiscalContext())
            {
                List<T> result = fiscalContext.Set<T>().ToList();
                return result;
            }
        }

        public void Save<T>(List<T> items) where T : class
        {
            using (FiscalContext fiscalContext = new FiscalContext())
            {
                fiscalContext.Set<T>().AddRange(items);
                fiscalContext.SaveChanges();
            }
        }
    }
}

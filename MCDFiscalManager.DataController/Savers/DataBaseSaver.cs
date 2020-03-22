using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCDFiscalManager.BusinessModel.Model;
using System.Reflection;

namespace MCDFiscalManager.DataController.Savers
{
    public class DataBaseSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {

            using (FiscalContext context = new FiscalContext())
            {
                List<T> result = context.Set<T>().ToList();
                return result; 
            }
        }

        public void Update<T>(T item) where T : class
        {
            using(FiscalContext context = new FiscalContext())
            {
                if (item is IIdentifier)
                {
                    T element = context.Set<T>().Find(((IIdentifier)item).ID);
                    element = item;
                    context.SaveChanges();
                }
                else return;
            }
        }

        public void Add<T>(T item) where T : class
        {
            using (FiscalContext context = new FiscalContext())
            {
                context.Set<T>().Add(item);
                context.SaveChanges();
            }
        }

        public void Add<T>(ICollection<T> items) where T : class
        {
            using (FiscalContext context = new FiscalContext())
            {
                context.Set<T>().AddRange(items);
                context.SaveChanges();
            }
        }

        public void Delete<T>(T item) where T : class
        {
            using (FiscalContext context = new FiscalContext())
            {
                if (item is IIdentifier)
                {
                    T element = context.Set<T>().Find(((IIdentifier)item).ID);
                    context.Set<T>().Remove(element);
                    context.SaveChanges();
                }
                else return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.DataController
{
    public interface IDataSaver
    {
        void Update<T>(T item) where T : class;
        void Add<T>(T item) where T : class;
        void Add<T>(ICollection<T> items) where T : class;
        void Delete<T>(T item) where T : class;
        List<T> Load<T>() where T : class;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.DataController
{
    public interface IDataSaver
    {
        void Save<T>(List<T> items) where T : class;
        List<T> Load<T>() where T : class;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace MCDFiscalManager.DataController.Savers
{
    public class BinnarySaver : IDataSaver
    {
        private const int NumberOfRetries = 3;
        private const int DelayOnRetry = 500;
        public List<T> Load<T>() where T : class
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileInfo file = GetDataFile(typeof(T));

            for (int i = 0; i<= NumberOfRetries; ++i)
            {
                try
                {
                    using (FileStream fs = file.OpenRead())
                    {
                        if (fs.Length > 0 && binaryFormatter.Deserialize(fs) is IList<T> items)
                        {
                            return items.ToList<T>();
                        }
                        break;
                    }
                }
                catch (IOException e) when (i<=NumberOfRetries)
                {
                    Thread.Sleep(DelayOnRetry);
                }
            }
            return new List<T>();
        }

        public  void Save<T>(IList<T> items) where T : class
        {
            var binaryFormatter = new BinaryFormatter();
            FileInfo fileName = GetDataFile(typeof(T));
            using (FileStream fs = fileName.OpenWrite())
            {
                binaryFormatter.Serialize(fs, items);
            }
                
        }

        FileInfo GetDataFile(Type T)
        {
            string filePath = Path.GetFullPath(@".\data\" + T.Name + ".bin");
            FileInfo result = new FileInfo(filePath);
            if (!result.Exists) result.Create();
            return result;
        }
    }
}

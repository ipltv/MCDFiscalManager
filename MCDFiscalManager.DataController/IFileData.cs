using System.Runtime.Serialization;
using System.IO;

namespace MCDFiscalManager.DataController
{
    interface IFileData
    {
        void LoadDataFromFile(IFormatter formatter, FileInfo file);
        void SaveDataToFile(IFormatter formatter, FileInfo file);
    }
}

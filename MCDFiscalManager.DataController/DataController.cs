using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCDFiscalManager.BusinessModel.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MCDFiscalManager.DataController
{
    public class DataController
    {
        private Dictionary<string, FiscalPrinter> fiscalPrinters;
        private Dictionary<int, Company> companyByShortNumber;
        private Dictionary<string, Company> companyByShortName;
        
        public DataController()
        {
            fiscalPrinters = new Dictionary<string, FiscalPrinter>();
        }
        /// <summary>
        /// Загружает данные о фискальных принтерах из CSV-файла заданного формата.
        /// Строки не соответствующего формата игнорируются.
        /// Первая строка (заголовок) игнорируется.
        /// Возвращает число успешно загруженных принтеров.
        /// </summary>
        /// <param name="dataFile">Объект FileInfo представляющий файл с данными о ФР.</param>
        /// <returns>Число успешно загруженных записей.</returns>
        public int LoadPrinterDataFormFile(FileInfo dataFile)
        {
            if (dataFile.Extension != ".csv")
                throw new FileLoadException("Файл загрузки данных должен быть CSV-файлом", nameof(dataFile));
            int count = 0;
            using (StreamReader reader = new StreamReader(dataFile.FullName))
            {
                FiscalPrinter tempPrinter = null;
                reader.ReadLine();
                while(reader.Peek() > -1)
                {
                    tempPrinter = stringDataAnalyzer(reader.ReadLine());
                    if (tempPrinter != null)
                    {
                        fiscalPrinters.Add(tempPrinter.SerialNumber, tempPrinter);
                        count++;
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// Конструирует объект FiscalPrinter на основе данных из входной строки.
        /// Строка должна строго соответсвовать установленному шаблону.
        /// </summary>
        /// <param name="line">Входная строка, содержащая данные для создания объекта FiscalPrinter.</param>
        /// <returns>Объект FiscalPrinter построенный на основе входых данных.</returns>
        private FiscalPrinter stringDataAnalyzer(string line)
        {
            string[] data = line.Split(new char[] {',',';'});
            FiscalMemory fiscalMemory = new FiscalMemory(data[4], data[5], null, null);
            Adress adress = new Adress(postcode: data[6], codeOfRegion: data[7], street: data[8], house:data[9],building: data[10]);
            FiscalPrinter fiscalPrinter = new FiscalPrinter(data[2], data[3], null, null, "", fiscalMemory, adress: adress); ; ;
            return fiscalPrinter;
        }
        /// <summary>
        /// Создает шаблон загрузочного файла для формирования заявлений о регистрации ККТ.
        /// </summary>
        /// <param name="root">Объект представляющий директорию, в которой требуется создать шаблон.</param>
        public static void CreateTemplateRegistrationFile(DirectoryInfo root)
        {
            FileInfo file = new FileInfo(Path.Combine(root.FullName, "TemplateRegistrationFile.csv"));
            
            using (StreamWriter writer = new StreamWriter(file.Create(),Encoding.UTF8))
            { 
                writer.WriteLine(@"Номер ПБО; Название ПБО; Серийный номер ККТ; Модель ККТ; Серийный номер ФН; Модель ФН; Почтовый индекс; Код региона; Улица; Дом; Корпус/Литер/Иной признак строения;");
            }
            
        }
    }
}

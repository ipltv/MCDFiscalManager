using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCDFiscalManager.BusinessModel.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using GC = System.GC;

namespace MCDFiscalManager.DataController
{
    public class FiscalDataController
    {
        private Dictionary<string, FiscalPrinter> fiscalPrinters;
        private Dictionary<string, Company> companyByShortName;
        private User user;
        private OFD ofd;

        public FiscalDataController()
        {
            fiscalPrinters = new Dictionary<string, FiscalPrinter>();
            companyByShortName = new Dictionary<string, Company>();
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
            Store storePlace = this.StoreDataFromFile(new FileInfo(Environment.CurrentDirectory + @"\data\storedata.xlsx"), data[0]);
            
            FiscalMemory fiscalMemory = new FiscalMemory(serialNumber: data[3], 
                                                            model: data[4], null, null);
            
            Adress adress = new Adress(postcode: data[5], 
                                        codeOfRegion: data[6], 
                                        street: data[7], 
                                        house:data[8],
                                        building: data[9]);
            
            FiscalPrinter fiscalPrinter = new FiscalPrinter(serialNumber: data[1],
                                                            model: data[2],
                                                            placeOfInstallation: storePlace,
                                                            registrationDate: null,
                                                            registrationNumber:"", 
                                                            fiscalMemory: fiscalMemory, 
                                                            adress: adress); ; ;
            
            return fiscalPrinter;
        }
        /// <summary>
        /// Создает шаблон загрузочного файла для формирования заявлений о регистрации ККТ.
        /// </summary>
        /// <param name="root">Объект представляющий директорию, в которой требуется создать шаблон.</param>
        public static void CreateTemplateRegistrationFile(DirectoryInfo root)
        {
            if (!root.Exists) root.Create();
            FileInfo file = new FileInfo(Path.Combine(root.FullName, "TemplateRegistrationFile.csv"));
            
            using (StreamWriter writer = new StreamWriter(file.Create(),Encoding.UTF8))
            { 
                writer.WriteLine(@"Номер ПБО; Серийный номер ККТ; Модель ККТ; Серийный номер ФН; Модель ФН; Почтовый индекс; Код региона; Улица; Дом; Корпус/Литер/Иной признак строения;");
            }
            
        }

        public Store StoreDataFromFile(FileInfo fileInfo, string storeNumber)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(fileInfo.FullName);
            Excel.Worksheet worksheet = workbook.Sheets[1];
            try
            {
                int row = 1;
                while (worksheet.Cells[row, 1].Value.ToString() != "")
                {
                    if (worksheet.Cells[row, 1].Value.ToString() == storeNumber)
                    {
                        Company own; companyByShortName.TryGetValue(worksheet.Cells[row, 5].Value.ToString(), out own);
                        return new Store(number: worksheet.Cells[row, 1].Value.ToString(),
                                        name: worksheet.Cells[row, 2].Value.ToString(),
                                        owner: own,
                                        trrc: worksheet.Cells[row, 4].Value.ToString(),
                                        taxAuthoritiesCode: worksheet.Cells[row, 6].Value.ToString());
                    }
                    row++;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Возникла ошибка при поиске данных о ПБО",ex);
            }
            finally
            {
                workbook.Close(false);
                excelApp.Quit();
                worksheet = null;
                workbook = null;
                excelApp = null;
                GC.Collect();
            }
            return null;
        }

        public bool LoadUserDataFromTextFile(FileInfo file)
        {
            using(StreamReader reader = new StreamReader(file.FullName))
            {
                string[] lines = reader.ReadLine().Split(',');
                User result = new User(lines[1], lines[0], lines[2]);
                user = result;
                return true;
            }
        }

        public bool LoadOFDDataFromTextFile(FileInfo file)
        {
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                string[] lines = reader.ReadLine().Split(',');
                OFD result = new OFD(lines[0], @lines[1]);
                ofd = result;
                return true;
            }
        }
        public void LoadCompanyListFromFile(FileInfo file)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(file.FullName, FileMode.Open);
                List<Company> tempList = (List<Company>)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                companyByShortName.Clear();
                foreach (Company tempCompany in tempList)
                {
                    companyByShortName.Add(tempCompany.ShortName, tempCompany);
                }
            }
            catch (Exception throwedException)
            {
                throw new SerializationException("Возникла ошибка при загрузке справочника компаний. Данные не будут загружены.", throwedException);
            }
        }

        public void SaveCompanyListToFile(FileInfo file)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(file.FullName, FileMode.OpenOrCreate);
                binaryFormatter.Serialize(fileStream, companyByShortName.Values.ToList<Company>());
                fileStream.Close();
            }
            catch (Exception throwedException)
            {

                throw new SerializationException("Возникла ошибка сохранении справочника компаний.",throwedException);
            }
        }

        public void AddCompany(Company addItem)
        {
            companyByShortName.Add(addItem.ShortName, addItem);
        }
        public void RemoveCompany(string shortName)
        {
            companyByShortName.Remove(shortName);
        }

        public void CreateXMLFiles()
        {
            foreach(KeyValuePair<string,FiscalPrinter> temp in fiscalPrinters)
            {
                XMLDocumentController.CreateXMLDocument(temp.Value, user, ofd);
            }
        }
    }
}

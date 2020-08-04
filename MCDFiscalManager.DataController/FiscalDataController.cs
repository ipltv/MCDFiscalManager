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
using Dadata;
using Dadata.Model;

namespace MCDFiscalManager.DataController
{
    public class FiscalDataController
    {
        private Dictionary<string, FiscalPrinter> fiscalPrinters;
        private Dictionary<string, Company> companyByShortName;
        private User user;
        private OFD ofd;
        private Excel.Application excelApplication;
        private Dadata.Model.Address address;

        private Store lastLoadedStore;

        public FiscalDataController()
        {
            fiscalPrinters = new Dictionary<string, FiscalPrinter>();
            companyByShortName = new Dictionary<string, Company>();
            excelApplication = new Excel.Application();
            lastLoadedStore = null;
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
            int count = 0;
            if ((dataFile.Extension != ".xlsx") || (dataFile.Extension != ".xls"))
            {
                using (StreamReader reader = new StreamReader(dataFile.FullName))
                {
                    Excel.Workbook workbook = excelApplication.Workbooks.Open(dataFile.FullName);
                    Excel.Worksheet sheet = workbook.Sheets[1];
                    int i = 2;
                    while (!string.IsNullOrEmpty(sheet.Cells[i, 1].Text))
                    {
                        FiscalPrinter tempPrinter = stringDataAnalyzer(sheet.Rows[i]);
                        if (tempPrinter != null)
                        {
                            fiscalPrinters.Add(tempPrinter.SerialNumber, tempPrinter);
                            count++;
                        }
                        i++;
                    }
                }
            }
            else
            {
                throw new FileLoadException("Файл загрузки данных должен быть Excel-файлом", nameof(dataFile));
            }

            return count;
        }
        /// <summary>
        /// Конструирует объект FiscalPrinter на основе данных из входной строки.
        /// Строка должна строго соответсвовать установленному шаблону.
        /// </summary>
        /// <param name="line">Входная строка, содержащая данные для создания объекта FiscalPrinter.</param>
        /// <returns>Объект FiscalPrinter построенный на основе входых данных.</returns>
        private FiscalPrinter stringDataAnalyzer(Excel.Range range)
        {
            string storeNumber = range.Cells[1, 1].Value.ToString();
            Store storePlace;
            if ((lastLoadedStore != null) && (lastLoadedStore.Number == storeNumber)) storePlace = lastLoadedStore;
            else storePlace = this.StoreDataFromFile(new FileInfo(Environment.CurrentDirectory + @"\data\storedata.xlsx"), storeNumber);

            string serialNumberFM = range.Cells[1, 4].Value.ToString();
            string modelFM = range.Cells[1, 5].Value.ToString();
            FiscalMemory fiscalMemory = new FiscalMemory(serialNumber: serialNumberFM,
                                                            model: modelFM, null, null);

            //string postcodeA = range.Cells[1, 6].Value.ToString();
            //string codeOfRegionA = range.Cells[1, 7].Value.ToString();
            //string city = range.Cells[1, 8].Value.ToString();
            //string streetA = range.Cells[1, 9].Value.ToString();
            //string houseA = range.Cells[1, 10].Value.ToString();
            //string buildingA = "";
            //if (!string.IsNullOrEmpty(range.Cells[1, 11].Value)) buildingA = range.Cells[1, 11].Value.ToString();
            //Adress adress = new Adress(postcode: postcodeA,
            //                            codeOfRegion: codeOfRegionA,
            //                            city: city,
            //                            street: streetA,
            //                            house: houseA,
            //                            building: buildingA);

            string serialNumberFP = range.Cells[1, 2].Value.ToString();
            string modelFP = range.Cells[1, 3].Value.ToString();
            FiscalPrinter fiscalPrinter = new FiscalPrinter(serialNumber: serialNumberFP,
                                                            model: modelFP,
                                                            placeOfInstallation: storePlace,
                                                            registrationDate: null,
                                                            registrationNumber: "",
                                                            fiscalMemory: fiscalMemory,
                                                            adress: address);
            
            lastLoadedStore = storePlace;
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

            using (StreamWriter writer = new StreamWriter(file.Create(), Encoding.UTF8))
            {
                writer.WriteLine(@"Номер ПБО; Серийный номер ККТ; Модель ККТ; Серийный номер ФН; Модель ФН; Почтовый индекс; Код региона; Улица; Дом; Корпус/Литер/Иной признак строения;");
            }

        }

        public Store StoreDataFromFile(FileInfo fileInfo, string storeNumber)
        {
            Excel.Workbook workbook = excelApplication.Workbooks.Open(fileInfo.FullName);
            Excel.Worksheet worksheet = workbook.Sheets[1];
            try
            {
                int row = 1;
                while (worksheet.Cells[row, 1].Value.ToString() != "")
                {
                    if (worksheet.Cells[row, 1].Value.ToString() == storeNumber)
                    {
                        Company own; companyByShortName.TryGetValue(worksheet.Cells[row, 5].Value.ToString(), out own);
                        string fiasID = worksheet.Cells[row,7].Value.ToString();
                        var token = "6db25055841906ecbdce72aaff286795ecb1dace";
                        var api = new SuggestClient(token);
                        var response = api.FindAddress(fiasID);
                        address = response.suggestions[0].data;
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

                throw new Exception("Возникла ошибка при поиске данных о ПБО", ex);
            }
            finally
            {
                workbook.Close(false);
                worksheet = null;
                workbook = null;
                GC.Collect();
            }
            return null;
        }

        public bool LoadUserDataFromTextFile(FileInfo file)
        {
            using (StreamReader reader = new StreamReader(file.FullName))
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

                throw new SerializationException("Возникла ошибка сохранении справочника компаний.", throwedException);
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

        public void CreateXMLFiles(DirectoryInfo outputDir)
        {
            foreach (KeyValuePair<string, FiscalPrinter> temp in fiscalPrinters)
            {
                XMLDocumentController.CreateXMLDocument(temp.Value, user, ofd, outputDir, temp.Value.Adress);
            }
        }
    }
}

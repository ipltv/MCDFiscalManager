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
    public class FiscalDataController : AuxiliaryDataController<FiscalPrinter>
    {
        private Dictionary<string, FiscalPrinter> fiscalPrinters;
        private Dictionary<string, Company> companyByShortName;
        private User user;
        private OFD ofd;
        private Excel.Application excelApplication; // to remove
        private FileInfo storeDataFile; //to remove

        private Store lastLoadedStore;

        /// <summary>
        /// Создает новый объект класса FiscalDataController представляющий методы для обработки данных о фискальных регистраторах.
        /// </summary>
        /// <param name="storeData">Объект FileInfo содржащий файл с данными о ПБО.</param>
        public FiscalDataController(FileInfo storeData)
        {
            storeDataFile = storeData;
            fiscalPrinters = new Dictionary<string, FiscalPrinter>();
            companyByShortName = new Dictionary<string, Company>();
            excelApplication = new Excel.Application();
            lastLoadedStore = null;
        }
        /// <summary>
        /// Создает новый объект класса FiscalDataController представляющий методы для обработки данных о фискальных регистраторах.
        /// </summary>
        /// <param name="storeData">Объект FileInfo содржащий файл с данными о ПБО.</param>
        /// <param name="userData">Контроллер данных пользователей.</param>
        /// <param name="companyData">Контроллер данных о компаниях.</param>
        /// <param name="ofdData">Контроллер данных ОФД.</param>
        public FiscalDataController
            (FileInfo storeData, 
             UserDataController userData, 
             CompanyDataController companyData, 
             OFDDataController ofdData) : this(storeData)
        {
            storeDataFile = storeData;
            //userDataController = userData;
            //companyDataController = companyData;
            //ofdDataController = ofdData;
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
        /// Конструирует объект FiscalPrinter на основе данных из входного объекта Range.
        /// Объект Range должен строго соответсвовать установленному шаблону.
        /// </summary>
        /// <param name="range">Объект Excel.Range, содержащий строку с данными для создания объекта FiscalPrinter.</param>
        /// <returns>Объект FiscalPrinter построенный на основе входых данных.</returns>
        private FiscalPrinter stringDataAnalyzer(Excel.Range range)
        {
            //Определени номера ПБО.
            //Поиск данных о ПБО, номер которого содаржится в первой ячейке переданного диапазона.
            //Если данные о ПБО с этим номером были загружены при предыдущем вызовы метода StoreDataFromFile поиск не осуществляется.
            string storeNumber = range.Cells[1, 1].Value.ToString();
            Store storePlace;
            if ((lastLoadedStore != null) && (lastLoadedStore.Number == storeNumber))
            { storePlace = lastLoadedStore; }
            else
            {
                storePlace = this.StoreDataFromFile(storeDataFile, storeNumber);
                lastLoadedStore = storePlace;
            }
            //Чтение данных о фискальном накопителе из ячеек переданного Range
            string serialNumberFM = range.Cells[1, 4].Value.ToString(); //Серийный номер фискального накопителя из 4ой ячейки.  
            string modelFM = range.Cells[1, 5].Value.ToString(); //Модель ФН из 5ой ячейки
            FiscalMemory fiscalMemory = new FiscalMemory(serialNumber: serialNumberFM,
                                                            model: modelFM, null, null);

            //Чтение данных о адресе из ячеек переданного Range
            string postcodeA = range.Cells[1, 6].Value.ToString(); //Индекс из ячийки 6
            string codeOfRegionA = range.Cells[1, 7].Value.ToString(); //Код региона из ячейки 7
            string city = range.Cells[1, 8].Value.ToString(); //Город из ячейки 8
            string streetA = range.Cells[1, 9].Value.ToString(); // Улица из ячейки 9
            string houseA = range.Cells[1, 10].Value.ToString(); // Номер дома из ячейки 10
            string buildingA = "";
            if (!string.IsNullOrEmpty(range.Cells[1, 11].Value)) buildingA = range.Cells[1, 11].Value.ToString(); // Признак строения (корпус, литера и пр.) из ячейки 11, если она не пустая.
            Adress adress = new Adress(postcode: postcodeA,
                                        codeOfRegion: codeOfRegionA,
                                        city: city,
                                        street: streetA,
                                        house: houseA,
                                        building: buildingA);
            //Чтение данных о фискальном регистраторе и создание результирующего объекта с использованием ранее созданных FiscalMemory и Adress.
            string serialNumberFP = range.Cells[1, 2].Value.ToString(); //Серийный номер фискального принтера из ячейки 2
            string modelFP = range.Cells[1, 3].Value.ToString(); //Модель ФП из ячейки 3
            FiscalPrinter fiscalPrinter = new FiscalPrinter(serialNumber: serialNumberFP,
                                                            model: modelFP,
                                                            storePlace,
                                                            placeOfInstallation: $"{storePlace.Number} {storePlace.Number}",
                                                            registrationDate: null,
                                                            registrationNumber: "",
                                                            fiscalMemory: fiscalMemory,
                                                            adress: adress);
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
                writer.WriteLine(@"Номер ПБО; Серийный номер ККТ; Модель ККТ; Серийный номер ФН; Модель ФН; Код региона; Почтовый индекс; Район; Город; Населенный пункт; Улица; Дом; Корпус/Литер/Иной признак строения; ");
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
                        return new Store(number: worksheet.Cells[row, 1].Value.ToString(),
                                        name: worksheet.Cells[row, 2].Value.ToString(),
                                        owner: own,
                                        trrc: worksheet.Cells[row, 4].Value.ToString(),
                                        taxAuthoritiesCode: worksheet.Cells[row, 6].Value.ToString(),
                                        adress: new Adress(codeOfRegion: worksheet.Cells[row, 7].Value.ToString(),
                                                            postcode: worksheet.Cells[row, 8].Value.ToString(),
                                                            district: worksheet.Cells[row,9].Value,
                                                            city: worksheet.Cells[row,10].Value,
                                                            locality: worksheet.Cells[row, 11].Value,
                                                            street: worksheet.Cells[row,12].Value,
                                                            house:worksheet.Cells[row,13].Value,
                                                            building:worksheet.Cells[row,14].Value,
                                                            flat: worksheet.Cells[row,15].Value));
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
                worksheet = null;
                workbook.Close(false);
                
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
                XMLDocumentController.CreateRegistrationStatement(temp.Value, user, ofd, outputDir);
            }
        }
        public override bool SetCurrentElement(string serialNumber)
        {
            FiscalPrinter item = Elements.FirstOrDefault(t => t.SerialNumber == serialNumber);
            if (item != null)
            {
                curentElement = item;
                return true;
            }
            else { return false; }
        }
    }
}

using MCDFiscalManager.DataController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MCDFiscalManager.BusinessModel.Model;
using System.Globalization;
using System.Configuration;
namespace MCDFiscalManager.CMDInterface
{
    class Program
    {
        private static FileInfo storeDataFile;
        private static FileInfo ofdDataFile;
        private static FileInfo usersDataFile;
        private static FileInfo companyDataFile;
        private static DirectoryInfo outputDirectory;
        private static DirectoryInfo inputDirectory;
        static void Main(string[] args)
        {
            Initialize();


            FiscalDataController mainData = new FiscalDataController();
            mainData.LoadCompanyListFromFile(companyDataFile);
            mainData.LoadUserDataFromTextFile(usersDataFile);
            mainData.LoadOFDDataFromTextFile(ofdDataFile);
            //FiscalDataController.CreateTemplateRegistrationFile(outputDirectory);

            FileInfo[] files = inputDirectory.GetFiles();
            foreach (FileInfo file in files)
            {
                if ((file.Extension == ".xlsx") || (file.Extension == ".xls"))
                {
                    try
                    {
                        mainData.LoadPrinterDataFormFile(file);
                        mainData.CreateXMLFiles(outputDirectory);
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                    {
                        Console.WriteLine("Не удалось до конца прочитать файл. Данные будут сформированы для успешно считаных ФН.");
                        mainData.CreateXMLFiles(new DirectoryInfo(Environment.CurrentDirectory + @"\output"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Произошла ошибка при обработке файла {file.Name}.\nОригинальное сообщение:\n{ex}");
                    }
                }
                else
                {
                    Console.WriteLine($"Файл {file.Name} не будет обработан, так как его расширение не поддерживается");
                }

            }
            Console.WriteLine("Program is end working. Press Enter for exit...");
            Console.ReadLine();
        }

        public static void Initialize()
        {
            #region Initialization of application file variables from the configuration file
            try
            {
                AppSettingsReader appSettingsReader = new AppSettingsReader();
                DataFileInitialization(appSettingsReader, "StoreDataFilePath", out storeDataFile);
                DataFileInitialization(appSettingsReader, "OFDDataFilePath", out ofdDataFile);
                DataFileInitialization(appSettingsReader, "UsersDataFilePath", out usersDataFile);
                DataFileInitialization(appSettingsReader, "CompanyDataFilePath", out companyDataFile);
                DirectoryInitialization(appSettingsReader, "InputDirectory", out inputDirectory);
                DirectoryInitialization(appSettingsReader, "OutputDirectory", out outputDirectory);

            }
            catch (FileNotFoundException fileNotEx)
            {
                throw new FileNotFoundException($"Возникла ошибка доступа/наличия файлов инициализации.\nОригинальное сообщение: {fileNotEx}", fileNotEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Возникла ошибка инициализации приложения.\nОригинальное сообщение:{ex}", ex);
            }
            #endregion
            #region CultureInstalling
            var culture = CultureInfo.GetCultureInfo("ru-RU");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            #endregion
        }

        private static void DataFileInitialization(AppSettingsReader appSettingsReader, string configFileValue, out FileInfo file)
        {
            string configDataFilePath = (string)appSettingsReader.GetValue(configFileValue, typeof(string));
            if (Path.IsPathRooted(configDataFilePath))
                file = new FileInfo(configDataFilePath);
            else file = new FileInfo(Path.Combine(Environment.CurrentDirectory, configDataFilePath));
            if (!file.Exists) throw new FileNotFoundException($"Не удалось найти файл с данными: {file.FullName}", nameof(configDataFilePath));
        }
        
        private static void DirectoryInitialization(AppSettingsReader appSettingsReader, string configParametr, out DirectoryInfo directory)
        {
            string directoryPath = (string)appSettingsReader.GetValue(configParametr, typeof(string));
            if (Path.IsPathRooted(directoryPath))
                directory = new DirectoryInfo(directoryPath);
            else directory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, directoryPath));
            if (!directory.Exists) directory.Create();
        }
    }
}

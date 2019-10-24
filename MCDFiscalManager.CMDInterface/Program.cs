using MCDFiscalManager.DataController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MCDFiscalManager.BusinessModel.Model;
using System.Globalization;
namespace MCDFiscalManager.CMDInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.GetCultureInfo("ru-RU");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            FiscalDataController mainData = new FiscalDataController();
            mainData.LoadCompanyListFromFile(new FileInfo(Environment.CurrentDirectory + @"\bin\company.bin"));
            mainData.LoadUserDataFromTextFile(new FileInfo(Environment.CurrentDirectory + @"\data\user.txt"));
            mainData.LoadOFDDataFromTextFile(new FileInfo(Environment.CurrentDirectory + @"\data\ofd.txt"));
            FiscalDataController.CreateTemplateRegistrationFile(new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, @"output")));

            FileInfo[] files = (new DirectoryInfo(Environment.CurrentDirectory + @"\input")).GetFiles();
            foreach (FileInfo file in files)
            {
                if ((file.Extension == ".xlsx") || (file.Extension == ".xls"))
                {
                    try
                    {
                        mainData.LoadPrinterDataFormFile(file);
                        mainData.CreateXMLFiles(new DirectoryInfo(Environment.CurrentDirectory + @"\output"));
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
            Console.WriteLine("ok");
            Console.ReadLine();
        }
    }
}

using MCDFiscalManager.DataController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MCDFiscalManager.BusinessModel.Model;
namespace MCDFiscalManager.CMDInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            FiscalDataController mainData = new FiscalDataController();
            mainData.LoadCompanyListFromFile(new FileInfo(Environment.CurrentDirectory + @"\bin\company.bin"));
            mainData.LoadUserDataFromTextFile(new FileInfo(Environment.CurrentDirectory + @"\data\user.txt"));
            mainData.LoadOFDDataFromTextFile(new FileInfo(Environment.CurrentDirectory + @"\data\ofd.txt"));
            FiscalDataController.CreateTemplateRegistrationFile(new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, @"output")));
            mainData.LoadPrinterDataFormFile(new FileInfo(Environment.CurrentDirectory + @"\input\TemplateRegistrationFile.csv"));
            mainData.CreateXMLFiles();
            Console.WriteLine("ok");
            Console.ReadLine();
        }
    }
}

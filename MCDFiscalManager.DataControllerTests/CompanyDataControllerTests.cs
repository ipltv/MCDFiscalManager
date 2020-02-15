using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCDFiscalManager.DataController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MCDFiscalManager.BusinessModel.Model;
using System.Threading;

namespace MCDFiscalManager.DataController.Tests
{
    [TestClass()]
    public class CompanyDataControllerTests
    {
        [TestMethod()]
        public void CompanyDataControllerTest()
        {
            int NumberOfRetries = 3;
            int DelayOnRetry = 1000;

            // Выбираем директорию для временных файлов. Если ее нет, то создаем.
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Tests"));
            if (!directory.Exists) directory.Create();
            else
            {
                // Если скопилось больше 10 файлов от предыдущих тестов, удаляем их.
                FileInfo[] files = directory.GetFiles();
                if (files.Length > 10)
                    foreach (FileInfo file in files)
                        file.Delete();
            }
            //Создаем нового пользователя и помещаем его в контроллер
            Company company = new Company("ООО НИЛЬС", "ООО НИЛЬС", "000000001", "000");
            CompanyDataController companyDataController = new CompanyDataController(company);

            // Сохраняем контроллер
            companyDataController.SaveData();

            // Созадем еще 1 контроллер и загружаем в него информацию из только что сохраненного файла.
            CompanyDataController companyDataController1 = null;
            //Делаем 3 попытки с задержкой 1000 мс, на случай проблем/задержек в механизме ввода-вывода.
            for (int i = 1; i <= NumberOfRetries; i++)
            {
                try
                {
                    companyDataController1 = new CompanyDataController();
                }
                catch (IOException) when (i <= NumberOfRetries)
                {
                    Thread.Sleep(DelayOnRetry);
                }
            }
            // Строковые представления объектов равны, т.е. объекты имеют одинаковое состояние
            Assert.AreEqual(companyDataController.GetCurrentElement().ToString(), companyDataController1.GetCurrentElement().ToString());
            // При этом ссылки указывают на разные области памяти, т.е. это не один и тот же объект.
            Assert.AreNotEqual(companyDataController, companyDataController1);
        }

        [TestMethod()]
        public void CompanyDataControllerTest1()
        {
            Company company = new Company("ООО НИЛЬС", "ООО НИЛЬС", "000000001", "000");
            CompanyDataController companyDataController = new CompanyDataController(company);
            Assert.AreEqual(company, companyDataController.GetCurrentElement());
        }

        [TestMethod()]
        public void SetCurrentElementTest()
        {
            Company company = new Company("ООО НИЛЬС", "ООО НИЛЬС", "000000001", "000");
            CompanyDataController companyDataController = new CompanyDataController(company);
            Assert.IsTrue(companyDataController.SetCurrentElement(company.TIN));
            Assert.AreEqual(company, companyDataController.GetCurrentElement());
        }

        [TestMethod()]
        public void AddElementTest()
        {
            Company company = new Company("ООО НИЛЬС", "ООО НИЛЬС", "000000001", "ООО");
            Company company1 = new Company("LLC Vesta", "LLC Vesta", "000000002", "LLC");
            CompanyDataController companyDataController = new CompanyDataController(company);
            companyDataController.AddElement(company1);
            Assert.AreEqual(2, companyDataController.Count);
        }

        [TestMethod()]
        public void RemoveElementTest()
        {
            Company company = new Company("ООО НИЛЬС", "ООО НИЛЬС", "000000001", "ООО");
            Company company1 = new Company("LLC Vesta", "LLC Vesta", "000000002", "LLC");
            CompanyDataController companyDataController = new CompanyDataController(company);
            companyDataController.AddElement(company1);
            Assert.AreEqual(2, companyDataController.Count);
            companyDataController.RemoveElement(company);
            Assert.AreEqual(1, companyDataController.Count);
            Assert.AreEqual(company1, companyDataController.GetCurrentElement());
        }
    }
}
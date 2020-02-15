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
    public class OFDDataControllerTests
    {
        [TestMethod()]
        public void OFDDataControllerTest()
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
            OFD ofd = new OFD("77777777", "OFD NILS");
            OFDDataController ofdDataController = new OFDDataController(ofd);

            // Сохраняем контроллер.
            ofdDataController.SaveData();

            // Созадем еще 1 контроллер и загружаем в него информацию из только что сохраненного файла.
            OFDDataController ofdDataController1 = null;
            //Делаем 3 попытки с задержкой 1000 мс, на случай проблем/задержек в механизме ввода-вывода.
            for (int i = 1; i <= NumberOfRetries; i++)
            {
                try
                {
                    ofdDataController1 = new OFDDataController();
                }
                catch (IOException) when (i <= NumberOfRetries)
                {
                    Thread.Sleep(DelayOnRetry);
                }
            }
            // Строковые представления объектов равны, т.е. объекты имеют одинаковое состояние
            Assert.AreEqual(ofdDataController.GetCurrentElement().ToString(), ofdDataController1.GetCurrentElement().ToString());
            // При этом ссылки указывают на разные области памяти, т.е. это не один и тот же объект.
            Assert.AreNotEqual(ofdDataController, ofdDataController1);
        }

        [TestMethod()]
        public void OFDDataControllerTest1()
        {
            OFD ofd = new OFD("77777777", "OFD NILS");
            OFDDataController ofdDataController = new OFDDataController(ofd);
            Assert.AreEqual(ofd, ofdDataController.GetCurrentElement());
        }

        [TestMethod()]
        public void SetCurrentElementTest()
        {
            OFD ofd = new OFD("77777777", "OFD NILS");
            OFDDataController ofdDataController = new OFDDataController(ofd);
            Assert.IsTrue(ofdDataController.SetCurrentElement(ofd.TIN));
            Assert.AreEqual(ofd, ofdDataController.GetCurrentElement());
        }

        [TestMethod()]
        public void AddElementTest()
        {
            OFD ofd = new OFD("77777777", "OFD NILS");
            OFD ofd1 = new OFD("1111111", "OFD VESTA");
            OFDDataController ofdDataController = new OFDDataController(ofd);
            ofdDataController.AddElement(ofd1);
            Assert.AreEqual(2, ofdDataController.Count);
        }

        [TestMethod()]
        public void RemoveElementTest()
        {
            OFD ofd = new OFD("77777777", "OFD NILS");
            OFD ofd1 = new OFD("1111111", "OFD VESTA");
            OFDDataController ofdDataController = new OFDDataController(ofd);
            ofdDataController.AddElement(ofd1);
            Assert.AreEqual(2, ofdDataController.Count);
            ofdDataController.RemoveElement(ofd);
            Assert.AreEqual(1, ofdDataController.Count);
            Assert.AreEqual(ofd1, ofdDataController.GetCurrentElement());
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCDFiscalManager.DataController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCDFiscalManager.BusinessModel.Model;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace MCDFiscalManager.DataController.Tests
{
    [TestClass()]
    public class UserDataControllerTests
    {
        [TestMethod]
        /// <summary>
        /// Общий метод ля тестирования конструктора, который восстанавливает данные контроллера из файла с использованием различных форматтеров.
        /// </summary>
        /// <param name="formatter">Форматтер файла, с помощью которого будет сохранено, а затем восстановлено состояние контроллера пользователя.</param>
        public void UserDataControllerTest()
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
            User user = new User("Ivan", "Ivanov", "Ivanovich");
            UserDataController userDataController = new UserDataController(user);

            // Сохраняем контроллер.
            userDataController.SaveData();

            // Созадем еще 1 контроллер и загружаем в него информацию из только что сохраненного файла.
            UserDataController userDataController1 = null;
            //Делаем 3 попытки с задержкой 1000 мс, на случай проблем/задержек в механизме ввода-вывода.
            for (int i = 1; i <= NumberOfRetries; i++)
            {
                try
                {
                    userDataController1 = new UserDataController();
                }
                catch (IOException) when (i <= NumberOfRetries)
                {
                    Thread.Sleep(DelayOnRetry);
                }
            }
            // Строковые представления объектов равны, т.е. объекты имеют одинаковое состояние
            Assert.AreEqual(userDataController.GetCurrentElement().ToString(), userDataController1.GetCurrentElement().ToString());
            // При этом ссылки указывают на разные области памяти, т.е. это не один и тот же объект.
            Assert.AreNotEqual(userDataController, userDataController1);
        }
        /// <summary>
        /// Метод тестирования конструктора контроллера пользователей, который принимает только одного нового пользователя.
        /// </summary>
        [TestMethod()]
        public void UserDataControllerTest1()
        {
            User user = new User("Ivan", "Ivanov", "Ivanovich");
            UserDataController userDataController = new UserDataController(user);
            Assert.AreEqual(user, userDataController.GetCurrentElement());
        }
        /// <summary>
        /// Тест метода установки текущего пользователя.
        /// </summary>
        [TestMethod()]
        public void SetCurrentElementTest()
        {
            User user = new User("Ivan", "Ivanov", "Ivanovich");
            UserDataController userDataController = new UserDataController(user);
            Assert.IsTrue(userDataController.SetCurrentElement(user.Surname));
            Assert.AreEqual(user, userDataController.GetCurrentElement());
        }

        [TestMethod()]
        public void AddElementTest()
        {
            User user = new User("Ivan", "Ivanov", "Ivanovich");
            UserDataController userDataController = new UserDataController(user);

            User user1 = new User("Semen", "Semenov", "Semenovich");
            userDataController.AddElement(user1);
            userDataController.SetCurrentElement("Semenov");
            Assert.AreEqual(user1, userDataController.GetCurrentElement());
        }

        [TestMethod()]
        public void RemoveElementTest()
        {
            User user = new User("Ivan", "Ivanov", "Ivanovich");
            UserDataController userDataController = new UserDataController(user);

            User user1 = new User("Semen", "Semenov", "Semenovich");
            userDataController.AddElement(user1);
            userDataController.SetCurrentElement("Semenov");
            Assert.AreEqual(user1, userDataController.GetCurrentElement());
            userDataController.RemoveElement(user1);
            Assert.AreEqual(user, userDataController.GetCurrentElement());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCDFiscalManager.BusinessModel.Model;
using System.Runtime.Serialization;
using System.IO;
namespace MCDFiscalManager.DataController
{
    /// <summary>
    /// Класс представляющий интерфейс для взаимодействия с данными о пользователях.
    /// </summary>
    public class UserDataController : AuxiliaryDataController<User>
    {
        public UserDataController(IFormatter formatter, FileInfo userDataFile) : base(formatter, userDataFile) {  }
        public UserDataController(User user): base(user.Surname,user) { }
        public override User this[string value]
        {
            get
            {
                User result;
                elements.TryGetValue(value, out result);
                return result;
            }
        }
        public override bool SetCurrentElement(string surname)
        {
            User userBySurname = elements.Values.FirstOrDefault(p => p.Surname == surname);
            if (userBySurname != null)
            {
                curentElement = userBySurname;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void AddElement(User element)
        {
            elements.Add(element.Surname, element);
        }
        public override void RemoveElement(User element)
        {
            User deletedUser = elements[element.Surname];
            elements.Remove(element.Surname);

            if (curentElement == deletedUser)
            {
                curentElement = elements.Values.FirstOrDefault(p => p != null);
            }
        }
    }
}

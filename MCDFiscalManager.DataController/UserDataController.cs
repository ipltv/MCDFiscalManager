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
        public UserDataController() { }
        public UserDataController(User user): base(user) { }
        public override bool SetCurrentElement(string surname)
        {
            User userBySurname = Elements.FirstOrDefault(p => p.Surname == surname);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.BusinessModel.Model
{
    /// <summary>
    /// Класс представляющий данные о пользователе.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public string Patronymic { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Создает класс представляющий пользователя.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        public User (string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"[Name:{Name}; Surmane:{Surname}; Patronymic:{Patronymic};]";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion
    }
}

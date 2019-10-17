using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.BusinessModel.Model
{
    /// <summary>
    /// Класс представляющий фискальный принтер/регистратор.
    /// </summary>
    public class FiscalPrinter
    {
        #region Fields
        /// <summary>
        /// Поле представляющее место установки фискального принтера
        /// </summary>
        private Store placeOfInstallation;
        private FiscalMemory currentFiscalMemory;
        private Adress currentAdress;
        #endregion
        #region Properties
        /// <summary>
        /// Серийный номер фискального принтера. Только для чтения.
        /// </summary>
        public string SerialNumber
        {
            get;
        }
        /// <summary>
        /// Модель фискального принтера. Только для чтения.
        /// </summary>
        public string Model { get; }
        /// <summary>
        /// Дата регистрации фискального принтера в НО. Только для чтения.
        /// </summary>
        public DateTime? RegistrationDate { get; private set; }
        /// <summary>
        /// Место установки фискального принтера.
        /// </summary>
        public Store PlaceOfInstallation
        {
            get => placeOfInstallation;
            set
            {
                placeOfInstallation = value;
            }
        }
        /// <summary>
        /// Регистрационный номер присвоенный фискальному регистратору (ФР) налоговым органом.
        /// </summary>
        public string RegistrationNumder { get; set; }
        /// <summary>
        /// Возвращает текущий объект FiscalMemory.
        /// </summary>
        public FiscalMemory FiscalMemory { get { return currentFiscalMemory; } }
        /// <summary>
        /// Возвращает текущий объект Adress.
        /// </summary>
        public Adress Adress { get { return currentAdress; } }
        #endregion
        #region Constructors
        /// <summary>
        /// Создает экземпляр каласса представляющий фискальный принтер (ФР).
        /// </summary>
        /// <param name="serialNumber">Серийный номер ФР.</param>
        /// <param name="model">Модель ФР.</param>
        /// <param name="registrationDate">Дата регистрации ФР в налоговом органе.</param>
        /// <param name="placeOfInstallation">Место установки ФР.</param>
        /// <param name="registrationNumber">Регистрационный номер ФР присвоенный налоговым органом.</param>
        /// <param name="fiscalMemory">Экземпляр класса представляющий фискальный накопитель (ФН) установленный в данном ФР.</param>
        public FiscalPrinter
            (string serialNumber, 
            string model,
            Store placeOfInstallation,
            DateTime? registrationDate = null,         
            string registrationNumber = "", 
            FiscalMemory fiscalMemory = null,
            Adress adress = null)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
            {
                throw new ArgumentNullException("Серийный номер фискального принтера не может быть пустым или null.", nameof(serialNumber));
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("Модель фискального принтера не может быть пустой или null.", nameof(model));
            }

            PlaceOfInstallation = placeOfInstallation ?? throw new ArgumentNullException("Место установки фискального принтера не может быть null.", nameof(placeOfInstallation));
            RegistrationNumder = registrationNumber ?? throw new ArgumentNullException("Регистрационный номер фискального принтера не может быть null.", nameof(registrationNumber));
            SerialNumber = serialNumber;
            Model = model;
            RegistrationDate = registrationDate;          
            currentFiscalMemory = fiscalMemory;
            currentAdress = adress;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"[Serial Number:{SerialNumber}; Model:{Model}; Registration Date:{RegistrationDate}; Place Of Installation:{PlaceOfInstallation}; Registration Numder:{RegistrationNumder}; Fiscal Memory:{currentFiscalMemory};]";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion
    }
}

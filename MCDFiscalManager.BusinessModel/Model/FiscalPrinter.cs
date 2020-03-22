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
    public class FiscalPrinter : IIdentifier
    {
        #region Fields
        /// <summary>
        /// Поле представляющее место установки фискального принтера
        /// </summary>
        private string placeOfInstallation;
        private Store division;
        private FiscalMemory currentFiscalMemory;
        private Address currentAdress;
        private OFD currentOFD;
        #endregion
        #region Properties
        /// <summary>
        /// Id фискального принтера для EF.
        /// </summary>
        public int ID { get; set; }
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
        public string PlaceOfInstallation
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
        public Address Adress { get { return currentAdress; } }
        /// <summary>
        /// Возвращает или устанавливает текущий объект ОФД.
        /// </summary>
        public OFD OFD { get => currentOFD; set { currentOFD = value; } }
        /// <summary>
        /// Обособленное подразделение, к которому привязан ФР.
        /// </summary>
        public Store Division { get => division; set { division = value; } }
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
            Store division,
            string placeOfInstallation = "",
            DateTime? registrationDate = null,         
            string registrationNumber = "", 
            FiscalMemory fiscalMemory = null,
            Address adress = null)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
            {
                throw new ArgumentNullException("Серийный номер фискального принтера не может быть пустым или null.", nameof(serialNumber));
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("Модель фискального принтера не может быть пустой или null.", nameof(model));
            }
            if (string.IsNullOrWhiteSpace(placeOfInstallation))
            {
                placeOfInstallation = $"{division.Number} {division.Name}";
            }

            Division = division ?? throw new ArgumentNullException("Подразделение установки фискального принтера не может быть null.", nameof(division));
            RegistrationNumder = registrationNumber ?? throw new ArgumentNullException("Регистрационный номер фискального принтера не может быть null.", nameof(registrationNumber));
            
            PlaceOfInstallation = placeOfInstallation;
            SerialNumber = serialNumber;
            Model = model;
            RegistrationDate = registrationDate;          
            currentFiscalMemory = fiscalMemory;
            currentAdress = adress ?? Division.Address;
        }
        public FiscalPrinter() { }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"[Serial Number:{SerialNumber}; Model:{Model}; Registration Date:{RegistrationDate}; Place Of Installation:{PlaceOfInstallation}; Registration Numder:{RegistrationNumder}; Fiscal Memory:{currentFiscalMemory}; OFD:{OFD}; Division:{Division};]";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion
    }
}

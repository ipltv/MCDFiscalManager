using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.BusinessModel.Model
{
    /// <summary>
    /// Класс представляющий фискальную память принтера - фискальный накопитель (ФН).
    /// </summary>
    public class FiscalMemory
    {
        #region Properties
        /// <summary>
        /// Серийный номер фискального накопителя. Только для чтения.
        /// </summary>
        public string SerialNumber { get; }
        /// <summary>
        /// Модель фискального накопителя. Только для чтения.
        /// </summary>
        public string Model { get; }
        /// <summary>
        /// Дата регистрации фискального накопителя в НО.Только для чтения.
        /// </summary>
        public DateTime? RegistrationDate { get; }
        /// <summary>
        /// Дата окончания срока действия фискального накопителя. Только для чтения.
        /// </summary>
        public DateTime? ExpirationDate { get; }
        #endregion
        #region Сonstructors
        /// <summary>
        /// Создает экзепляр класса представляющий фискальный накопитель (ФН).
        /// </summary>
        /// <param name="serialNumber">Серийный номер ФН</param>
        /// <param name="model">Модель ФН</param>
        /// <param name="registrationDate">Дата регистрации</param>
        /// <param name="expirationDate">Дата окончания срока дейтсвия</param>
        public FiscalMemory 
            (string serialNumber, 
            string model, 
            DateTime? registrationDate = null, 
            DateTime? expirationDate = null)
        {
            #region DataChek
            if (string.IsNullOrWhiteSpace(serialNumber)) 
            {
                throw new ArgumentNullException("Серийный номер не может быть пустым или null.",nameof(serialNumber));
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("Модель не может быть пустой или null.", nameof(model));
            }
            if (registrationDate >= expirationDate)
            {
                throw new ArgumentException("Дата регистрациии ФН не может быть позже или равной дате окончания срока действия ФН.", nameof(registrationDate));
            }
            #endregion
            SerialNumber = serialNumber;
            Model = model;
            RegistrationDate = registrationDate;
            ExpirationDate = expirationDate;
        }
        #endregion
    }
}

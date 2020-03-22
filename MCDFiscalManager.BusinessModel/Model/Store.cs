using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.BusinessModel.Model
{
    [Serializable]
    public class Store : IIdentifier
    {
        #region Properties
        /// <summary>
        /// Id ПБО для EF.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Номер ПБО.
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Название ПБО.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Управляющая компания ПБО.
        /// </summary>
        public Company Owner { get; set; }
        /// <summary>
        /// КПП обособленного подразделения.
        /// </summary>
        public string TRRC { get; set; }
        /// <summary>
        /// Код регистрирующего налогового органа.
        /// </summary>
        public string TaxAuthoritiesCode { get; set; }
        /// <summary>
        /// Адрес ПБО.
        /// </summary>
        public Address Address { get; set; }
        #endregion
        #region Constructions
        public Store (string number, string name, Company owner, string trrc, string taxAuthoritiesCode, Address address)
        {
            if (string.IsNullOrWhiteSpace(number)) throw new ArgumentException("Номер ПБО не может быть пустым.", nameof(number));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Название ПБО не может быть пустым.", nameof(name));
            if (string.IsNullOrWhiteSpace(trrc)) throw new ArgumentException("КПП не может быть пустым.", nameof(trrc));
            if (string.IsNullOrWhiteSpace(taxAuthoritiesCode)) throw new ArgumentException("Код НО не может быть пустым.", nameof(taxAuthoritiesCode));
            Owner = owner ?? throw new ArgumentNullException("Юр. лицо ПБО не может быть null", nameof(owner));
            Name = name.Trim();
            Number = number.Trim();
            TRRC = trrc.Trim();
            TaxAuthoritiesCode = taxAuthoritiesCode.Trim();
            Address = address ?? throw new ArgumentNullException("Адрес не может быть пустым или null", nameof(address));
        }
        public Store() { }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"[Number:{Number}; Name:{Name}; Owner: {Owner}; TRRC:{TRRC}; TaxAuthoritiesCode:{TaxAuthoritiesCode}; Adress: {Address};]";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion
    }
}

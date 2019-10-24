using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.BusinessModel.Model
{
    /// <summary>
    /// Класс представляющий адрес объекта.
    /// </summary>
    public class Adress
    {
        #region Properties
        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// Код региона.
        /// </summary>
        public string CodeOfRegion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public string House { get; set; }
        /// <summary>
        /// Номер корпуса, строение, литера.
        /// </summary>
        public string Building { get; set; }
        #endregion
        #region Contructors
        public Adress(string postcode, string codeOfRegion, string city, string street, string house, string building)
        {
            if (string.IsNullOrWhiteSpace(postcode))
            {
                throw new ArgumentNullException("Индекс не может быть пустым или null.", nameof(postcode));
            }
            if (string.IsNullOrWhiteSpace(codeOfRegion))
            {
                throw new ArgumentNullException("Код региона не может быть пустым или null.", nameof(codeOfRegion));
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentNullException("Название города не может быть пустым или null", nameof(city));
            }
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentNullException("Название улицы не может быть пустым или null.", nameof(street));
            }
            if (string.IsNullOrWhiteSpace(house))
            {
                throw new ArgumentNullException("Номер дома не может быть пустым или null.", nameof(street));
            }
            Building = building ?? throw new ArgumentNullException("Номер корпуса не может быть пустым", nameof(building));
            Postcode = postcode;
            CodeOfRegion = codeOfRegion;
            City = city;
            Street = street;
            House = house;
        }
        #endregion
        #region Methods 
        public override string ToString()
        {
            return $"[Postcode:{Postcode}; CodeOfRegion:{CodeOfRegion}; City:{City}; Street:{Street}; House:{House}; Building:{Building};]";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion
    }
}

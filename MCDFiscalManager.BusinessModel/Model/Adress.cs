using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MCDFiscalManager.BusinessModel.Model
{
    /// <summary>
    /// Класс представляющий адрес объекта.
    /// </summary>
    public class Address
    {
        private const int PostcodeMaxLengthConst = 6;
        /// <summary>
        /// ID записи адреса для EF.
        /// </summary>
        public int AddressID { get; set; }
        #region Fields
        private string codeOfRegion;
        private string postcode;
        private string district;
        private string city;
        private string locality;
        private string street;
        private string house;
        private string building;
        private string flat;
        #endregion
        #region Properties
        /// <summary>
        /// Задает или возвращает почтовый индекс.
        /// </summary>
        public string Postcode
        {
            get
            {
                return postcode;
            }
            set
            {
                if (value != null)
                {
                    postcode = value;
                }
                else throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
            }
        }
        /// <summary>
        /// Задает или возвращает код региона.
        /// </summary>
        public string CodeOfRegion
        {
            get
            {
                return codeOfRegion;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
                if (Regex.IsMatch(value, @"^[0-9]{2}$") && value.Length == 2)
                {
                    codeOfRegion = value;
                }
                else
                {
                    throw new ArgumentException(ModelResurses.AdressCodeOfRegionException, nameof(value));
                }

            }
        }
        /// <summary>
        /// Задает и возвращает район объекта.
        /// </summary>
        public string District
        {
            get
            {
                return district;
            }
            set
            {
                if (value != null)
                {
                    district = value;
                }
                else throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
            }
        }
        /// <summary>
        /// Задает или возвращает город объекта.
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value != null)
                {
                    city = value;
                }
                else throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
            }
        }
        /// <summary>
        /// Задает или возвращает населенный пункт.
        /// </summary>
        public string Locality
        {
            get
            {
                return locality;
            }
            set
            {
                if (value != null)
                {
                    locality = value;
                }
                else throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
            }
        }
        /// <summary>
        /// Задает или возвращает улицу объекта.
        /// </summary>
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                if (value != null)
                {
                    street = value;
                }
                else throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
            }
        }
        /// <summary>
        /// Задает или возвращает номер дома объекта.
        /// </summary>
        public string House
        {
            get
            {
                return house;
            }
            set
            {
                if (value != null)
                {
                    house = value;
                }
                else throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
            }
        }
        /// <summary>
        /// Задает или возвращает номер корпуса, строения, литерау
        /// </summary>
        public string Building
        {
            get
            {
                return building;
            }
            set
            {
                if (value != null)
                {
                    building = value;
                }
                else throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
            }
        }
        /// <summary>
        /// Задает или возвращает квартиру/офис объекта.
        /// </summary>
        public string Flat
        {
            get
            {
                return flat;
            }
            set
            {
                if (value != null)
                {
                    flat = value;
                }
                else throw new ArgumentNullException(nameof(value), ModelResurses.AdressNullException);
            }
        }
        #endregion
        #region Contructors
        public Address(string codeOfRegion, 
            string postcode = "", 
            string district = "", 
            string city = "", 
            string locality = "", 
            string street = "", 
            string house = "", 
            string building = "", 
            string flat = "")
        {
            // Присвоение параметров объекта.
            // Проверка null и формата данных реализована в свойствах.

            CodeOfRegion = codeOfRegion;
            Postcode = postcode;
            District = district;
            City = city;
            Locality = locality;
            Street = street;
            House = house;
            Building = building;
            Flat = flat;
        }
        #endregion
        #region Methods 
        public override string ToString()
        {
            return $"[CodeOfRegion:{CodeOfRegion}; Postcode:{Postcode}; District:{District}; City:{City}; Locality:{Locality}; Street:{Street}; House:{House}; Building:{Building}; Flat:{Flat};]";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion
    }
}

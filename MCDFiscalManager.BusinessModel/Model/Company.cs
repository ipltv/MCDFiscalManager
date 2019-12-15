using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MCDFiscalManager.BusinessModel.Model
{
    [Serializable]
    public class Company
    {
        #region Properties
        /// <summary>
        /// ID компании для EF.
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Полное наименование компании.
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Короткое название компании.
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Организационно-правовая форма компании.
        /// </summary>
        public string LegalForm { get; set; }
        /// <summary>
        /// ИНН компании.
        /// </summary>
        public string TIN { get; set; }
        #endregion
        #region Constructions
        public Company(string fullName, string shortName, string tin, string legalFOrm = "")
        {
            FullName = fullName;
            ShortName = shortName;
            TIN = tin;
            LegalForm = legalFOrm;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"[Full Name:{FullName}; Short Name:{ShortName}; Legal Form:{LegalForm}; TIN:{TIN};]";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion
    }
}

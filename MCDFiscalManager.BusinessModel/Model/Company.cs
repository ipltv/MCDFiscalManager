using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.BusinessModel.Model
{
    [Serializable]
    public class Company
    {
        #region Properties
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string LegalForm { get; set; }
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

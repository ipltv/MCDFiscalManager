using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.BusinessModel.Model
{
    [Serializable]
    public class OFD
    {
        /// <summary>
        /// ИНН ОФД.
        /// </summary>
        public string TIN { get; set; }
        /// <summary>
        /// Полное наименование ОФД.
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Создает объект инкапсулирующий данные о ОФД.
        /// </summary>
        /// <param name="tin">ИНН ОФД</param>
        /// <param name="fullName">Полное наименование юр. лица ОФД.</param>
        public OFD(string tin, string fullName)
        {
            TIN = tin;
            FullName = fullName;
        }
    }
}

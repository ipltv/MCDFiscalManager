using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MCDFiscalManager.BusinessModel.Model;

namespace MCDFiscalManager.DataController
{
    public static class McDonaldsRussiaDataCreator
    {
        /// <summary>
        /// Создает файл-справочник компаний Макдоналдс в России для дальнейшего использования другими компонентами.
        /// </summary>
        /// <param name="file">Объект FileInfo представляющий файл, в который должна быть помещена информация.</param>
        public static void CreateMcDonaldsCompanyFile(FileInfo file)
        {
            FiscalDataController fiscalDataController = new FiscalDataController(new FileInfo(""));
            Company mcdonaldsCJCS = new Company("ЗАКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО \"МОСКВА - МАКДОНАЛДС\"", "ЗАО \"МОСКВА - МАКДОНАЛДС\"", "7710044132", "ЗАО");
            Company mcdonaldsLLC = new Company("ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ \"МАКДОНАЛДС\"","ООО \"МАКДОНАЛДС\"", "7710044140","ООО");
            Company nroLLC = new Company("ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ \"СРП\"", "ООО \"СРП\"", "7802668116", "ООО");
            Company sroLLC = new Company("ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ \"ЮРП\"", "ООО \"ЮРП\"", "9705119058", "ООО");
            fiscalDataController.AddCompany(mcdonaldsCJCS);
            fiscalDataController.AddCompany(mcdonaldsLLC);
            fiscalDataController.AddCompany(nroLLC);
            fiscalDataController.AddCompany(sroLLC);
            fiscalDataController.SaveCompanyListToFile(file);
        }
    }
}

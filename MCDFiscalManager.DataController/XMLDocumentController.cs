using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MCDFiscalManager.BusinessModel.Model;
using System.IO;
using Dadata;
using Dadata.Model;

namespace MCDFiscalManager.DataController
{
    public class XMLDocumentController
    {
        public static bool CreateXMLDocument(FiscalPrinter fiscalPrinter, User user, OFD ofd, DirectoryInfo outputDir, Dadata.Model.Address address)
        {
            XDocument doc = new XDocument();

            XElement file = new XElement("Файл");
            XAttribute progVersion = new XAttribute("ВерсПрог", "1.0");
            XAttribute formVersion = new XAttribute("ВерсФорм", "5.03");
            XAttribute fileID = new XAttribute("ИдФайл", "KO_ZVLREGKKT");

            file.Add(progVersion, formVersion, fileID);

            XElement document = new XElement("Документ");
            XAttribute CND = new XAttribute("КНД", "1110061");
            XAttribute documentDate = new XAttribute("ДатаДок", DateTime.Now.ToShortDateString());
            XAttribute codeNO = new XAttribute("КодНО", "7701");

            document.Add(CND, documentDate, codeNO);
            file.Add(document);

            XElement SVNP = new XElement("СвНП");
            XElement NPUL = new XElement("НПЮЛ");
            XAttribute orgNaim = new XAttribute("НаимОрг", fiscalPrinter.PlaceOfInstallation.Owner.FullName);
            XAttribute innUL = new XAttribute("ИННЮЛ", fiscalPrinter.PlaceOfInstallation.Owner.TIN);
            XAttribute kppUL = new XAttribute("КПП", fiscalPrinter.PlaceOfInstallation.TRRC);

            NPUL.Add(orgNaim, innUL, kppUL);
            SVNP.Add(NPUL);
            document.Add(SVNP);

            XElement singer = new XElement("Подписант");
            XAttribute sinRight = new XAttribute("ПрПодп", "2");
            singer.Add(sinRight);
            XElement FIO = new XElement("ФИО");
            XAttribute surname = new XAttribute("Фамилия", user.Surname);
            XAttribute name = new XAttribute("Имя", user.Name);
            XAttribute patronymic = new XAttribute("Отчество", user.Patronymic);

            FIO.Add(surname, name, patronymic);
            singer.Add(FIO);
            document.Add(singer);

            XElement statement = new XElement("ЗаявРегККТ");
            XAttribute codeNOPlace = new XAttribute("КодНОМУст", fiscalPrinter.PlaceOfInstallation.TaxAuthoritiesCode);
            XAttribute docType = new XAttribute("ВидДок", "1");

            statement.Add(codeNOPlace, docType);
            document.Add(statement);

            XElement intelligence = new XElement("СведРегККТ");
            XAttribute modelKKT = new XAttribute("МоделККТ", fiscalPrinter.Model);
            XAttribute numberKKT = new XAttribute("ЗаводНомерККТ", fiscalPrinter.SerialNumber);
            XAttribute modelFN = new XAttribute("МоделФН", fiscalPrinter.FiscalMemory.Model);
            XAttribute numberFN = new XAttribute("ЗаводНомерФН", fiscalPrinter.FiscalMemory.SerialNumber);
            XAttribute markOffline = new XAttribute("ПрАвтоном", "2");
            XAttribute markLottery = new XAttribute("ПрЛотерея", "2");
            XAttribute markExcitement = new XAttribute("ПрАзарт", "2");
            XAttribute markBank = new XAttribute("ПрБанкПлат", "2");
            XAttribute markAutoDevice = new XAttribute("ПрАвтоматУстр", "2");
            XAttribute markInternet = new XAttribute("ПрИнтернет", "2");
            XAttribute markDelivery = new XAttribute("ПрРазвозРазнос", "2");
            XAttribute markBlank = new XAttribute("ПрБланк", "2");
            XAttribute markAgent = new XAttribute("ПрПлатАгент", "2");
            XAttribute markExcise = new XAttribute("ПрАкцизТовар", "2");

            intelligence.Add(modelKKT, numberKKT, modelFN, numberFN, markOffline, markLottery, markExcitement, markBank, markAutoDevice, markInternet, markDelivery, markBlank, markAgent, markExcise);
            statement.Add(intelligence);

            XElement OFD = new XElement("СведОФД");
            XAttribute innULOFD = new XAttribute("ИННЮЛ", ofd.TIN);
            XAttribute orgNaimOFD = new XAttribute("НаимОрг", ofd.FullName);

            OFD.Add(innULOFD, orgNaimOFD);
            intelligence.Add(OFD);

            XElement installAdress = new XElement("СведАдрМУст");
            XAttribute installNaim = new XAttribute("НаимМУст", $"{fiscalPrinter.PlaceOfInstallation.Number} {fiscalPrinter.PlaceOfInstallation.Name}");

            installAdress.Add(installNaim);
            intelligence.Add(installAdress);

            XElement adressKKT = new XElement("АдрМУстККТ");
            #region Адрес ФИАС
            XElement adressFIAS = new XElement("АдрФИАС");

            XAttribute fiasID = new XAttribute("ИдНом", address.fias_id);
            XAttribute postCode = new XAttribute("Индекс", address.postal_code);
            

            XElement regionCodeElement = new XElement("Регион", address.region_kladr_id.Substring(0,2));

            
            //Legacy
            //XElement municipalAreaElement = new XElement("МуниципРайон", null);
            //if (address.area_type != null && address.area != null)
            //{
            //    XAttribute areaType = new XAttribute("ВидКод", address.area_type);
            //    XAttribute areaName = new XAttribute("Наим", address.area);
            //    municipalAreaElement.Add(areaType, areaName);
            //}

            XElement municipalAreaElement = new XElement("МуниципРайон", null);
            if (address.city_type != null && address.city != null)
            {
                int cityCode = -1;
                if (address.city_type_full.Contains("муниц")) cityCode = 1;
                if (address.city_type_full.Contains("город")) cityCode = 2;
                if (address.city_type_full.Contains("внутри")) cityCode = 3;
                XAttribute cityType = new XAttribute("ВидКод", cityCode);
                XAttribute cityName = new XAttribute("Наим", address.city_with_type);
                municipalAreaElement.Add(cityType, cityName);
            }

            XElement townElement = new XElement("НаселенПункт", null);
            if (address.city_type_full != null && address.city != null)
            {
                XAttribute townType = new XAttribute("Вид", address.city_type_full);
                XAttribute townName = new XAttribute("Наим", address.city);
                townElement.Add(townType, townName);
            }

            XElement planElement = new XElement("ЭлПланСтруктур", null);
            if (address.city_district_type != null && address.city_district != null)
            {
                XAttribute planType = new XAttribute("Тип", address.city_district_type);
                XAttribute planName = new XAttribute("Наим", address.city_district);
                planElement.Add(planType, planName);
            }

            XElement streetElement = new XElement("ЭлУлДорСети", null);
            if (address.street_type_full != null && address.street != null)
            {
                XAttribute streetType = new XAttribute("Тип", address.street_type_full);
                XAttribute streetName = new XAttribute("Наим", address.street);
                streetElement.Add(streetType, streetName);
            }

            //XElement landElement = new XElement("ЗемелУчасток", null);
            XElement buildingElement = new XElement("Здание", null);
            if (address.house_type_full != null && address.house != null)
            {
                XAttribute buildingType = new XAttribute("Тип", address.house_type_full);
                string house = address.house;
                if (address.block_type_full != null && address.block != null)
                {
                    house += " " + address.block_type_full + " " + address.block;
                }
                XAttribute buildingNum = new XAttribute("Номер", house);
                buildingElement.Add(buildingType, buildingNum);
            }
            //XElement buildingPremisesElement = new XElement("ПомещЗдания", null);
            //XElement apartmentPremisesElement = new XElement("ПомещКвартиры", null);

            adressFIAS.Add(fiasID, postCode, regionCodeElement);
            if (municipalAreaElement.HasAttributes || municipalAreaElement.HasElements) adressFIAS.Add(municipalAreaElement);
            //if (cityAreaElement.HasAttributes || municipalAreaElement.HasElements) adressFIAS.Add(cityAreaElement);
            if (townElement.HasAttributes || townElement.HasElements) adressFIAS.Add(townElement);
            if (planElement.HasAttributes || planElement.HasElements) adressFIAS.Add(planElement);
            if (streetElement.HasAttributes || streetElement.HasElements) adressFIAS.Add(streetElement);
            if (buildingElement.HasAttributes || buildingElement.HasElements) adressFIAS.Add(buildingElement);

            adressKKT.Add(adressFIAS);
            #endregion    
            installAdress.Add(adressKKT);

            doc.Add(file);
            doc.Save(Path.Combine(outputDir.FullName, $"{fiscalPrinter.SerialNumber}.xml"));
            return true;
        }
    }
}

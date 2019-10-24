using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MCDFiscalManager.BusinessModel.Model;
using System.IO;
namespace MCDFiscalManager.DataController
{
    public class XMLDocumentController
    {
        public static bool CreateXMLDocument(FiscalPrinter fiscalPrinter, User user, OFD ofd, DirectoryInfo outputDir)
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
            XAttribute numberKKT = new XAttribute("НомерККТ", fiscalPrinter.SerialNumber);
            XAttribute modelFN = new XAttribute("МоделФН", fiscalPrinter.FiscalMemory.Model);
            XAttribute numberFN = new XAttribute("НомерФН", fiscalPrinter.FiscalMemory.SerialNumber);
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
            XAttribute postCode = new XAttribute("Индекс", fiscalPrinter.Adress.Postcode);
            XAttribute regionCode = new XAttribute("КодРегион", fiscalPrinter.Adress.CodeOfRegion);
            XAttribute city = new XAttribute("Город", fiscalPrinter.Adress.City);
            XAttribute street = new XAttribute("Улица", fiscalPrinter.Adress.Street);
            XAttribute house = new XAttribute("Дом", fiscalPrinter.Adress.House);
            XAttribute building = new XAttribute("Корпус", fiscalPrinter.Adress.Building);

            adressKKT.Add(postCode, regionCode, city, street, house);
            if (!string.IsNullOrWhiteSpace(building.Value)) adressKKT.Add(building);
            installAdress.Add(adressKKT);

            doc.Add(file);
            doc.Save(Path.Combine(outputDir.FullName, $"{fiscalPrinter.SerialNumber}.xml"));
            return true;
        }
    }
}

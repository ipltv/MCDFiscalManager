using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCDFiscalManager.BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDFiscalManager.BusinessModel.Model.Tests
{
    [TestClass()]
    public class AdressTests
    {
        [TestMethod()]
        public void AdressTest()
        {
            Address adress = new Address("76");
            Assert.IsNotNull(adress);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Address adress = new Address("76");
            string pattern = $"[CodeOfRegion:76; Postcode:; District:; City:; Locality:; Street:; House:; Building:; Flat:;]";
            Assert.AreEqual(adress.ToString(),pattern);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.Fail();
        }
    }
}
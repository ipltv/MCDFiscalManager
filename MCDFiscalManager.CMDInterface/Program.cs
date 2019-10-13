using MCDFiscalManager.DataController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MCDFiscalManager.CMDInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DataController.DataController.CreateTemplateRegistrationFile(new DirectoryInfo(Environment.CurrentDirectory));
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MCDFiscalManager.BusinessModel.Model;

namespace MCDFiscalManager.DataController
{
    /// <summary>
    /// Представляет контекст данный для работы с базой данных.
    /// </summary>
    public class FiscalContext : DbContext
    {
        public FiscalContext() : base("FiscalDBConnection") { }
        
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<FiscalMemory> FiscalMemories { get; set; }
        public DbSet<FiscalPrinter> FiscalPrinters { get; set; }
        public DbSet<OFD> OFDs { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

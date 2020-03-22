namespace MCDFiscalManager.DataController.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FDB_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Postcode = c.String(),
                        CodeOfRegion = c.String(),
                        District = c.String(),
                        City = c.String(),
                        Locality = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        Building = c.String(),
                        Flat = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        ShortName = c.String(),
                        LegalForm = c.String(),
                        TIN = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FiscalMemories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FiscalPrinters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegistrationDate = c.DateTime(),
                        PlaceOfInstallation = c.String(),
                        RegistrationNumder = c.String(),
                        Division_ID = c.Int(),
                        OFD_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stores", t => t.Division_ID)
                .ForeignKey("dbo.OFDs", t => t.OFD_ID)
                .Index(t => t.Division_ID)
                .Index(t => t.OFD_ID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Name = c.String(),
                        TRRC = c.String(),
                        TaxAuthoritiesCode = c.String(),
                        Address_ID = c.Int(),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Companies", t => t.Owner_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.OFDs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TIN = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FiscalPrinters", "OFD_ID", "dbo.OFDs");
            DropForeignKey("dbo.FiscalPrinters", "Division_ID", "dbo.Stores");
            DropForeignKey("dbo.Stores", "Owner_ID", "dbo.Companies");
            DropForeignKey("dbo.Stores", "Address_ID", "dbo.Addresses");
            DropIndex("dbo.Stores", new[] { "Owner_ID" });
            DropIndex("dbo.Stores", new[] { "Address_ID" });
            DropIndex("dbo.FiscalPrinters", new[] { "OFD_ID" });
            DropIndex("dbo.FiscalPrinters", new[] { "Division_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.OFDs");
            DropTable("dbo.Stores");
            DropTable("dbo.FiscalPrinters");
            DropTable("dbo.FiscalMemories");
            DropTable("dbo.Companies");
            DropTable("dbo.Addresses");
        }
    }
}

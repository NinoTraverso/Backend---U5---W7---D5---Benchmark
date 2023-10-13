namespace Inforno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dettagli",
                c => new
                    {
                        IdDettaglio = c.Int(nullable: false, identity: true),
                        ProdottoID = c.Int(nullable: false),
                        Quantita = c.Int(nullable: false),
                        OrdineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDettaglio)
                .ForeignKey("dbo.Ordini", t => t.OrdineID)
                .ForeignKey("dbo.Prodotti", t => t.ProdottoID)
                .Index(t => t.ProdottoID)
                .Index(t => t.OrdineID);
            
            CreateTable(
                "dbo.Ordini",
                c => new
                    {
                        IdOrdine = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(nullable: false, maxLength: 50),
                        Indirizzo = c.String(nullable: false, maxLength: 50),
                        DataOrdine = c.DateTime(nullable: false, storeType: "date"),
                        Nota = c.String(nullable: false, maxLength: 50),
                        Totale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdOrdine);
            
            CreateTable(
                "dbo.Prodotti",
                c => new
                    {
                        IdProdotto = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Foto = c.String(nullable: false, maxLength: 5),
                        Costo = c.Int(nullable: false),
                        Preparazione = c.Int(nullable: false),
                        Ingredienti = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdProdotto);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Role = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dettagli", "ProdottoID", "dbo.Prodotti");
            DropForeignKey("dbo.Dettagli", "OrdineID", "dbo.Ordini");
            DropIndex("dbo.Dettagli", new[] { "OrdineID" });
            DropIndex("dbo.Dettagli", new[] { "ProdottoID" });
            DropTable("dbo.Users");
            DropTable("dbo.Prodotti");
            DropTable("dbo.Ordini");
            DropTable("dbo.Dettagli");
        }
    }
}

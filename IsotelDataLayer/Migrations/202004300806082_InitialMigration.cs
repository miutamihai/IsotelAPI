namespace IsotelDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Landlords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.String(),
                        CityId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        PricePerDay = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.Id)
                .ForeignKey("dbo.Landlords", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Id", "dbo.Landlords");
            DropForeignKey("dbo.Rents", "Id", "dbo.Cities");
            DropIndex("dbo.Rents", new[] { "Id" });
            DropTable("dbo.Rents");
            DropTable("dbo.Landlords");
            DropTable("dbo.Cities");
        }
    }
}

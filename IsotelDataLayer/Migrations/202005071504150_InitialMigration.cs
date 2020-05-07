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
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Landlords",
                c => new
                    {
                        LandlordId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.LandlordId);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        RentId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        CityId = c.Int(nullable: false),
                        LandlordId = c.Int(nullable: false),
                        PricePerDay = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RentId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Landlords", t => t.LandlordId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.LandlordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "LandlordId", "dbo.Landlords");
            DropForeignKey("dbo.Rents", "CityId", "dbo.Cities");
            DropIndex("dbo.Rents", new[] { "LandlordId" });
            DropIndex("dbo.Rents", new[] { "CityId" });
            DropTable("dbo.Rents");
            DropTable("dbo.Landlords");
            DropTable("dbo.Cities");
        }
    }
}

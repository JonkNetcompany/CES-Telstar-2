namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class more_models : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Routes", newName: "Route");
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.Location_ID)
                .Index(t => t.Location_ID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Driver",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Company = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Levarance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Recommended = c.Boolean(nullable: false),
                        Package_ID = c.Int(),
                        Route_Id = c.Guid(),
                        Tracking_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Package", t => t.Package_ID)
                .ForeignKey("dbo.Route", t => t.Route_Id)
                .ForeignKey("dbo.Tracking", t => t.Tracking_ID)
                .Index(t => t.Package_ID)
                .Index(t => t.Route_Id)
                .Index(t => t.Tracking_ID);
            
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PackageType = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                        Location_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.Location_ID)
                .Index(t => t.Location_ID);
            
            CreateTable(
                "dbo.Tracking",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrentLocation_ID = c.Int(),
                        Signature_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.CurrentLocation_ID)
                .ForeignKey("dbo.Signature", t => t.Signature_ID)
                .Index(t => t.CurrentLocation_ID)
                .Index(t => t.Signature_ID);
            
            CreateTable(
                "dbo.Signature",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        signature = c.String(),
                        MyProperty_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.MyProperty_ID)
                .Index(t => t.MyProperty_ID);
            
            CreateTable(
                "dbo.Segment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Levarance", "Tracking_ID", "dbo.Tracking");
            DropForeignKey("dbo.Tracking", "Signature_ID", "dbo.Signature");
            DropForeignKey("dbo.Signature", "MyProperty_ID", "dbo.Customer");
            DropForeignKey("dbo.Tracking", "CurrentLocation_ID", "dbo.Location");
            DropForeignKey("dbo.Levarance", "Route_Id", "dbo.Route");
            DropForeignKey("dbo.Levarance", "Package_ID", "dbo.Package");
            DropForeignKey("dbo.Package", "Location_ID", "dbo.Location");
            DropForeignKey("dbo.Customer", "Location_ID", "dbo.Location");
            DropIndex("dbo.Signature", new[] { "MyProperty_ID" });
            DropIndex("dbo.Tracking", new[] { "Signature_ID" });
            DropIndex("dbo.Tracking", new[] { "CurrentLocation_ID" });
            DropIndex("dbo.Package", new[] { "Location_ID" });
            DropIndex("dbo.Levarance", new[] { "Tracking_ID" });
            DropIndex("dbo.Levarance", new[] { "Route_Id" });
            DropIndex("dbo.Levarance", new[] { "Package_ID" });
            DropIndex("dbo.Customer", new[] { "Location_ID" });
            DropTable("dbo.Segment");
            DropTable("dbo.Signature");
            DropTable("dbo.Tracking");
            DropTable("dbo.Package");
            DropTable("dbo.Levarance");
            DropTable("dbo.Driver");
            DropTable("dbo.Location");
            DropTable("dbo.Customer");
            RenameTable(name: "dbo.Route", newName: "Routes");
        }
    }
}

namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class icollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "Segment_ID", c => c.Int());
            AddColumn("dbo.Driver", "Levarance_ID", c => c.Int());
            AddColumn("dbo.Segment", "Route_Id", c => c.Guid());
            CreateIndex("dbo.Location", "Segment_ID");
            CreateIndex("dbo.Driver", "Levarance_ID");
            CreateIndex("dbo.Segment", "Route_Id");
            AddForeignKey("dbo.Driver", "Levarance_ID", "dbo.Levarance", "ID");
            AddForeignKey("dbo.Location", "Segment_ID", "dbo.Segment", "ID");
            AddForeignKey("dbo.Segment", "Route_Id", "dbo.Route", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Segment", "Route_Id", "dbo.Route");
            DropForeignKey("dbo.Location", "Segment_ID", "dbo.Segment");
            DropForeignKey("dbo.Driver", "Levarance_ID", "dbo.Levarance");
            DropIndex("dbo.Segment", new[] { "Route_Id" });
            DropIndex("dbo.Driver", new[] { "Levarance_ID" });
            DropIndex("dbo.Location", new[] { "Segment_ID" });
            DropColumn("dbo.Segment", "Route_Id");
            DropColumn("dbo.Driver", "Levarance_ID");
            DropColumn("dbo.Location", "Segment_ID");
        }
    }
}

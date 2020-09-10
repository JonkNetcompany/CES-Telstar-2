namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransportationTypeToSegmet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Segment", "TransportationType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Segment", "TransportationType");
        }
    }
}

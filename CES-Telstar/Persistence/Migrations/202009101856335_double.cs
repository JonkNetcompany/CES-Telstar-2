namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _double : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Levarance", "Time", c => c.Double(nullable: false));
            AlterColumn("dbo.Levarance", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Segment", "Time", c => c.Double(nullable: false));
            AlterColumn("dbo.Segment", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Segment", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Segment", "Time", c => c.Int(nullable: false));
            AlterColumn("dbo.Levarance", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Levarance", "Time", c => c.Int(nullable: false));
        }
    }
}

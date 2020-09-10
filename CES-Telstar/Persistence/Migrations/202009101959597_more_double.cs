namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class more_double : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Package", "Weight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Package", "Weight", c => c.Single(nullable: false));
        }
    }
}

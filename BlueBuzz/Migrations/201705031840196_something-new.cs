namespace BlueBuzz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingnew : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Title", c => c.String());
        }
    }
}

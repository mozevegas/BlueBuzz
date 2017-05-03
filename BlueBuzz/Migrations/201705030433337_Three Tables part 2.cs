namespace BlueBuzz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThreeTablespart2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.String(),
                        VolumeLevel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        TimeStart = c.DateTime(),
                        TimeEnd = c.DateTime(),
                        VenueId = c.Int(),
                        GenreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventGenres", t => t.GenreId)
                .ForeignKey("dbo.Venues", t => t.VenueId)
                .Index(t => t.VenueId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Venue = c.String(),
                        VenAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Events", "GenreId", "dbo.EventGenres");
            DropIndex("dbo.Events", new[] { "GenreId" });
            DropIndex("dbo.Events", new[] { "VenueId" });
            DropTable("dbo.Venues");
            DropTable("dbo.Events");
            DropTable("dbo.EventGenres");
        }
    }
}

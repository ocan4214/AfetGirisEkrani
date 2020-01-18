namespace AfetProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afet",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        GlideNo = c.String(),
                        FirstSeen = c.DateTime(nullable: false),
                        LastSeen = c.DateTime(nullable: false),
                        DaysLast = c.Int(),
                        DisasterType = c.String(),
                        Province = c.String(),
                        Borough = c.String(),
                        Village = c.String(),
                        Neighborhood = c.String(),
                        BeldeMevki = c.String(),
                        ReasonofDisaster = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        ReasonDetails = c.String(),
                        EffectedAreas = c.String(),
                        Source = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Afet");
        }
    }
}

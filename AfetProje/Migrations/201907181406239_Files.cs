namespace AfetProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Afet_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Afet", t => t.Afet_ID)
                .Index(t => t.Afet_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "Afet_ID", "dbo.Afet");
            DropIndex("dbo.File", new[] { "Afet_ID" });
            DropTable("dbo.File");
        }
    }
}

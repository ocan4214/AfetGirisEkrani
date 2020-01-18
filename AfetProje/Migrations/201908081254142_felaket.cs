namespace AfetProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class felaket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.File", "Afet_ID", "dbo.Afet");
            DropIndex("dbo.File", new[] { "Afet_ID" });
            AddColumn("dbo.File", "Afet_ID1", c => c.String(maxLength: 128));
            CreateIndex("dbo.File", "Afet_ID1");
            AddForeignKey("dbo.File", "Afet_ID1", "dbo.Afet", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "Afet_ID1", "dbo.Afet");
            DropIndex("dbo.File", new[] { "Afet_ID1" });
            DropColumn("dbo.File", "Afet_ID1");
            CreateIndex("dbo.File", "Afet_ID");
            AddForeignKey("dbo.File", "Afet_ID", "dbo.Afet", "ID");
        }
    }
}

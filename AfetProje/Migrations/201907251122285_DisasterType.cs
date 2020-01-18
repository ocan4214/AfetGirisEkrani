namespace AfetProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisasterType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Afet", "DisasterType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Afet", "DisasterType", c => c.String());
        }
    }
}

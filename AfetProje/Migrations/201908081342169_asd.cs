namespace AfetProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ilce",
                c => new
                    {
                        ILCE_ID = c.Long(nullable: false),
                        IL_ID = c.Long(),
                        ILCE_ADI_BUYUK = c.String(maxLength: 50),
                        ILCE_ADI = c.String(maxLength: 50),
                        ILCE_ADI_KUCUK = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ILCE_ID);
            
            CreateTable(
                "dbo.il",
                c => new
                    {
                        IL_ID = c.Long(nullable: false),
                        PLAKA = c.String(maxLength: 255),
                        IL_ADI_BUYUK = c.String(maxLength: 255),
                        IL_ADI = c.String(maxLength: 255),
                        IL_ADI_KUCUK = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.IL_ID);
            
            CreateTable(
                "dbo.mahalle_koy",
                c => new
                    {
                        MAH_ID = c.Long(nullable: false),
                        IL_ID = c.Long(),
                        ILCE_ID = c.Long(),
                        SEMT_ID = c.Long(),
                        MAHALLE_ADI_BUYUK = c.String(maxLength: 50),
                        MAHALLE_ADI = c.String(maxLength: 50),
                        MAHALLE_ADI_KUCUK = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MAH_ID);
            
            CreateTable(
                "dbo.semt",
                c => new
                    {
                        SEMT_ID = c.Long(nullable: false),
                        IL_ID = c.Long(),
                        ILCE_ID = c.Long(),
                        SEMT_ADI_BUYUK = c.String(maxLength: 50),
                        SEMT_ADI = c.String(maxLength: 50),
                        SEMT_ADI_KUCUK = c.String(maxLength: 50),
                        POSTA_KODU = c.String(maxLength: 7),
                    })
                .PrimaryKey(t => t.SEMT_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.semt");
            DropTable("dbo.mahalle_koy");
            DropTable("dbo.il");
            DropTable("dbo.ilce");
        }
    }
}

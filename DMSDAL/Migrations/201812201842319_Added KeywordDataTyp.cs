namespace DMSDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedKeywordDataTyp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeywordDataTypes",
                c => new
                    {
                        KeywordDataTypeId = c.Int(nullable: false, identity: true),
                        KeywordDataTypeName = c.String(),
                    })
                .PrimaryKey(t => t.KeywordDataTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KeywordDataTypes");
        }
    }
}

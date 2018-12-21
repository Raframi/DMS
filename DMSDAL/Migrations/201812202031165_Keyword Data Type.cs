namespace DMSDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeywordDataType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Keywords", "KeywordDataType_KeywordDataTypeId", c => c.Int());
            AlterColumn("dbo.KeywordDataTypes", "KeywordDataTypeName", c => c.String(nullable: false, maxLength: 60));
            CreateIndex("dbo.Keywords", "KeywordDataType_KeywordDataTypeId");
            AddForeignKey("dbo.Keywords", "KeywordDataType_KeywordDataTypeId", "dbo.KeywordDataTypes", "KeywordDataTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keywords", "KeywordDataType_KeywordDataTypeId", "dbo.KeywordDataTypes");
            DropIndex("dbo.Keywords", new[] { "KeywordDataType_KeywordDataTypeId" });
            AlterColumn("dbo.KeywordDataTypes", "KeywordDataTypeName", c => c.String());
            DropColumn("dbo.Keywords", "KeywordDataType_KeywordDataTypeId");
        }
    }
}

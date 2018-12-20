namespace DMSDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        DocumentTypeId = c.Int(nullable: false, identity: true),
                        DocumentTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        KeywordId = c.Int(nullable: false, identity: true),
                        KeywordName = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.KeywordId);
            
            CreateTable(
                "dbo.KeywordDocumentTypes",
                c => new
                    {
                        Keyword_KeywordId = c.Int(nullable: false),
                        DocumentType_DocumentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keyword_KeywordId, t.DocumentType_DocumentTypeId })
                .ForeignKey("dbo.Keywords", t => t.Keyword_KeywordId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_DocumentTypeId, cascadeDelete: true)
                .Index(t => t.Keyword_KeywordId)
                .Index(t => t.DocumentType_DocumentTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeywordDocumentTypes", "DocumentType_DocumentTypeId", "dbo.DocumentTypes");
            DropForeignKey("dbo.KeywordDocumentTypes", "Keyword_KeywordId", "dbo.Keywords");
            DropIndex("dbo.KeywordDocumentTypes", new[] { "DocumentType_DocumentTypeId" });
            DropIndex("dbo.KeywordDocumentTypes", new[] { "Keyword_KeywordId" });
            DropTable("dbo.KeywordDocumentTypes");
            DropTable("dbo.Keywords");
            DropTable("dbo.DocumentTypes");
        }
    }
}

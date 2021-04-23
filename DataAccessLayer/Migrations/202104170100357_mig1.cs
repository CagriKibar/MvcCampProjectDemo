namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Contents", "Content_ContentId", "dbo.Contents");
            DropIndex("dbo.Contents", new[] { "Category_CategoryId" });
            DropIndex("dbo.Contents", new[] { "Content_ContentId" });
            AddColumn("dbo.Contents", "WriterId", c => c.Int());
            AddColumn("dbo.Contents", "Writer_WriteId", c => c.Int());
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 20));
            CreateIndex("dbo.Contents", "Writer_WriteId");
            AddForeignKey("dbo.Contents", "Writer_WriteId", "dbo.Writers", "WriteId");
            DropColumn("dbo.Contents", "Category_CategoryId");
            DropColumn("dbo.Contents", "Content_ContentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "Content_ContentId", c => c.Int());
            AddColumn("dbo.Contents", "Category_CategoryId", c => c.Int());
            DropForeignKey("dbo.Contents", "Writer_WriteId", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "Writer_WriteId" });
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 520));
            DropColumn("dbo.Contents", "Writer_WriteId");
            DropColumn("dbo.Contents", "WriterId");
            CreateIndex("dbo.Contents", "Content_ContentId");
            CreateIndex("dbo.Contents", "Category_CategoryId");
            AddForeignKey("dbo.Contents", "Content_ContentId", "dbo.Contents", "ContentId");
            AddForeignKey("dbo.Contents", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}

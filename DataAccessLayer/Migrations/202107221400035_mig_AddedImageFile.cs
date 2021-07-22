namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_AddedImageFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 1000),
                        ImagePath = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}

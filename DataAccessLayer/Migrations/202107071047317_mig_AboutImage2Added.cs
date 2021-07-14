namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_AboutImage2Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutImage2");
        }
    }
}

namespace SurveyQuesion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aDDING6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Survey", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Survey", "Age", c => c.Int(nullable: false));
        }
    }
}

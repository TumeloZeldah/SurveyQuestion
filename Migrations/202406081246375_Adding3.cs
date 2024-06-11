namespace SurveyQuesion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Survey", "Food1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Survey", "Food2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Survey", "Food3", c => c.Boolean(nullable: false));
            AddColumn("dbo.Survey", "Food4", c => c.Boolean(nullable: false));
            DropColumn("dbo.Survey", "Food");
            DropColumn("dbo.Survey", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Survey", "IsSelected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Survey", "Food", c => c.String());
            DropColumn("dbo.Survey", "Food4");
            DropColumn("dbo.Survey", "Food3");
            DropColumn("dbo.Survey", "Food2");
            DropColumn("dbo.Survey", "Food1");
        }
    }
}

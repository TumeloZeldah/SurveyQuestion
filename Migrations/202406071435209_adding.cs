namespace SurveyQuesion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Survey", "IsSelected", c => c.Boolean(nullable: false));
            DropColumn("dbo.Survey", "Foods");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Survey", "Foods", c => c.String());
            DropColumn("dbo.Survey", "IsSelected");
        }
    }
}

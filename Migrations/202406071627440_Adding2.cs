namespace SurveyQuesion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Survey", "Food", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Survey", "Food");
        }
    }
}

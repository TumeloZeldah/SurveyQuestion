namespace SurveyQuesion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Survey", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Survey", "Age");
        }
    }
}

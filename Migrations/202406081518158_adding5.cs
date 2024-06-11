namespace SurveyQuesion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Survey", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Survey", "Age", c => c.Int(nullable: false));
        }
    }
}

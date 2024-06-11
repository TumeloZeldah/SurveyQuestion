namespace SurveyQuesion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullNames = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Contact = c.String(nullable: false),
                        Foods = c.String(),
                        Movies = c.Int(nullable: false),
                        Radio = c.Int(nullable: false),
                        EatOut = c.Int(nullable: false),
                        TV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Survey");
        }
    }
}

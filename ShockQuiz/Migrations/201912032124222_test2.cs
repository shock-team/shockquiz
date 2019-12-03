namespace ShockQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dificultads", "FactorDificultad", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dificultads", "FactorDificultad");
        }
    }
}

namespace ShockQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conjuntos", "tokenAPI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Conjuntos", "tokenAPI");
        }
    }
}

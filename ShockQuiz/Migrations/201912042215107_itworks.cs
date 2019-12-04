namespace ShockQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itworks : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Conjuntos", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Conjuntos", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}

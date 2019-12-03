namespace ShockQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Conjuntoes", newName: "Conjuntos");
            RenameTable(name: "dbo.Sesions", newName: "Sesiones");
            RenameTable(name: "dbo.Dificultads", newName: "Dificultades");
            AddColumn("dbo.Conjuntos", "tiempoEsperadoPorPregunta", c => c.Double(nullable: false));
            DropColumn("dbo.Dificultades", "FactorDificultad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dificultades", "FactorDificultad", c => c.Double(nullable: false));
            DropColumn("dbo.Conjuntos", "tiempoEsperadoPorPregunta");
            RenameTable(name: "dbo.Dificultades", newName: "Dificultads");
            RenameTable(name: "dbo.Sesiones", newName: "Sesions");
            RenameTable(name: "dbo.Conjuntos", newName: "Conjuntoes");
        }
    }
}

namespace ShockQuiz.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class owo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Respuestas", "id", "dbo.Preguntas");
            DropForeignKey("dbo.Respuestas", "PreguntaId", "dbo.Preguntas");
            DropIndex("dbo.Respuestas", new[] { "id" });
            DropIndex("dbo.Respuestas", new[] { "PreguntaId" });
            AddColumn("dbo.Respuestas", "EsCorrecta", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Respuestas", "PreguntaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Respuestas", "PreguntaId");
            AddForeignKey("dbo.Respuestas", "PreguntaId", "dbo.Preguntas", "id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Respuestas", "PreguntaId", "dbo.Preguntas");
            DropIndex("dbo.Respuestas", new[] { "PreguntaId" });
            AlterColumn("dbo.Respuestas", "PreguntaId", c => c.Int());
            DropColumn("dbo.Respuestas", "EsCorrecta");
            CreateIndex("dbo.Respuestas", "PreguntaId");
            CreateIndex("dbo.Respuestas", "id");
            AddForeignKey("dbo.Respuestas", "PreguntaId", "dbo.Preguntas", "id");
            AddForeignKey("dbo.Respuestas", "id", "dbo.Preguntas", "id");
        }
    }
}

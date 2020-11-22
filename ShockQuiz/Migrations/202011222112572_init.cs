namespace ShockQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Preguntas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 4000),
                        CategoriaId = c.Int(nullable: false),
                        DificultadId = c.Int(nullable: false),
                        ConjuntoId = c.Int(nullable: false),
                        idSesionActual = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Conjuntos", t => t.ConjuntoId, cascadeDelete: true)
                .ForeignKey("dbo.Dificultades", t => t.DificultadId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.DificultadId)
                .Index(t => t.ConjuntoId);
            
            CreateTable(
                "dbo.Conjuntos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        TiempoEsperadoPorPregunta = c.Double(nullable: false),
                        tokenAPI = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sesiones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidadPreguntas = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        DificultadId = c.Int(nullable: false),
                        puntaje = c.Double(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        fechaFin = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        ConjuntoId = c.Int(nullable: false),
                        RespuestasCorrectas = c.Int(nullable: false),
                        SegundosTranscurridos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Conjuntos", t => t.ConjuntoId, cascadeDelete: true)
                .ForeignKey("dbo.Dificultades", t => t.DificultadId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.DificultadId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ConjuntoId);
            
            CreateTable(
                "dbo.Dificultades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user = c.String(nullable: false, maxLength: 20),
                        password = c.String(nullable: false, maxLength: 20),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.user, unique: true);
            
            CreateTable(
                "dbo.Respuestas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        respuesta = c.String(nullable: false, maxLength: 4000),
                        EsCorrecta = c.Boolean(nullable: false),
                        PreguntaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Preguntas", t => t.PreguntaId, cascadeDelete: true)
                .Index(t => t.PreguntaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Respuestas", "PreguntaId", "dbo.Preguntas");
            DropForeignKey("dbo.Preguntas", "DificultadId", "dbo.Dificultades");
            DropForeignKey("dbo.Preguntas", "ConjuntoId", "dbo.Conjuntos");
            DropForeignKey("dbo.Sesiones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Sesiones", "DificultadId", "dbo.Dificultades");
            DropForeignKey("dbo.Sesiones", "ConjuntoId", "dbo.Conjuntos");
            DropForeignKey("dbo.Sesiones", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Preguntas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Respuestas", new[] { "PreguntaId" });
            DropIndex("dbo.Usuarios", new[] { "user" });
            DropIndex("dbo.Sesiones", new[] { "ConjuntoId" });
            DropIndex("dbo.Sesiones", new[] { "UsuarioId" });
            DropIndex("dbo.Sesiones", new[] { "DificultadId" });
            DropIndex("dbo.Sesiones", new[] { "CategoriaId" });
            DropIndex("dbo.Preguntas", new[] { "ConjuntoId" });
            DropIndex("dbo.Preguntas", new[] { "DificultadId" });
            DropIndex("dbo.Preguntas", new[] { "CategoriaId" });
            DropTable("dbo.Respuestas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Dificultades");
            DropTable("dbo.Sesiones");
            DropTable("dbo.Conjuntos");
            DropTable("dbo.Preguntas");
            DropTable("dbo.Categorias");
        }
    }
}

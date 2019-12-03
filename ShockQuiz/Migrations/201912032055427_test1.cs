namespace ShockQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Preguntas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        CategoriaId = c.Int(nullable: false),
                        DificultadId = c.Int(nullable: false),
                        ConjuntoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Conjuntoes", t => t.ConjuntoId, cascadeDelete: true)
                .ForeignKey("dbo.Dificultads", t => t.DificultadId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.DificultadId)
                .Index(t => t.ConjuntoId);
            
            CreateTable(
                "dbo.Conjuntoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sesions",
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
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Conjuntoes", t => t.ConjuntoId, cascadeDelete: true)
                .ForeignKey("dbo.Dificultads", t => t.DificultadId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.DificultadId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ConjuntoId);
            
            CreateTable(
                "dbo.Dificultads",
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
                        respuesta = c.String(nullable: false, maxLength: 100),
                        PreguntaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Preguntas", t => t.PreguntaId, cascadeDelete: true)
                .ForeignKey("dbo.Preguntas", t => t.id)
                .Index(t => t.id)
                .Index(t => t.PreguntaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Respuestas", "id", "dbo.Preguntas");
            DropForeignKey("dbo.Respuestas", "PreguntaId", "dbo.Preguntas");
            DropForeignKey("dbo.Preguntas", "DificultadId", "dbo.Dificultads");
            DropForeignKey("dbo.Preguntas", "ConjuntoId", "dbo.Conjuntoes");
            DropForeignKey("dbo.Sesions", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Sesions", "DificultadId", "dbo.Dificultads");
            DropForeignKey("dbo.Sesions", "ConjuntoId", "dbo.Conjuntoes");
            DropForeignKey("dbo.Sesions", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Preguntas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Respuestas", new[] { "PreguntaId" });
            DropIndex("dbo.Respuestas", new[] { "id" });
            DropIndex("dbo.Usuarios", new[] { "user" });
            DropIndex("dbo.Sesions", new[] { "ConjuntoId" });
            DropIndex("dbo.Sesions", new[] { "UsuarioId" });
            DropIndex("dbo.Sesions", new[] { "DificultadId" });
            DropIndex("dbo.Sesions", new[] { "CategoriaId" });
            DropIndex("dbo.Preguntas", new[] { "ConjuntoId" });
            DropIndex("dbo.Preguntas", new[] { "DificultadId" });
            DropIndex("dbo.Preguntas", new[] { "CategoriaId" });
            DropTable("dbo.Respuestas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Dificultads");
            DropTable("dbo.Sesions");
            DropTable("dbo.Conjuntoes");
            DropTable("dbo.Preguntas");
            DropTable("dbo.Categorias");
        }
    }
}

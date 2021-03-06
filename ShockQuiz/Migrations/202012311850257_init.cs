﻿namespace ShockQuiz.Migrations
{
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
                "dbo.Dificultades",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    nombre = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.id);

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

            CreateTable(
                "dbo.Sesiones",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    CantidadTotalPreguntas = c.Int(nullable: false),
                    puntaje = c.Double(nullable: false),
                    FechaInicio = c.DateTime(nullable: false),
                    fechaFin = c.DateTime(nullable: false),
                    UsuarioId = c.Int(nullable: false),
                    RespuestasCorrectas = c.Int(nullable: false),
                    SegundosTranscurridos = c.Double(nullable: false),
                    SesionFinalizada = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);

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
                "dbo.SesionPregunta",
                c => new
                {
                    PreguntaRefId = c.Int(nullable: false),
                    SesionRefId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.PreguntaRefId, t.SesionRefId })
                .ForeignKey("dbo.Preguntas", t => t.PreguntaRefId, cascadeDelete: true)
                .ForeignKey("dbo.Sesiones", t => t.SesionRefId, cascadeDelete: true)
                .Index(t => t.PreguntaRefId)
                .Index(t => t.SesionRefId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.SesionPregunta", "SesionRefId", "dbo.Sesiones");
            DropForeignKey("dbo.SesionPregunta", "PreguntaRefId", "dbo.Preguntas");
            DropForeignKey("dbo.Sesiones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Respuestas", "PreguntaId", "dbo.Preguntas");
            DropForeignKey("dbo.Preguntas", "DificultadId", "dbo.Dificultades");
            DropForeignKey("dbo.Preguntas", "ConjuntoId", "dbo.Conjuntos");
            DropForeignKey("dbo.Preguntas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.SesionPregunta", new[] { "SesionRefId" });
            DropIndex("dbo.SesionPregunta", new[] { "PreguntaRefId" });
            DropIndex("dbo.Usuarios", new[] { "user" });
            DropIndex("dbo.Sesiones", new[] { "UsuarioId" });
            DropIndex("dbo.Respuestas", new[] { "PreguntaId" });
            DropIndex("dbo.Preguntas", new[] { "ConjuntoId" });
            DropIndex("dbo.Preguntas", new[] { "DificultadId" });
            DropIndex("dbo.Preguntas", new[] { "CategoriaId" });
            DropTable("dbo.SesionPregunta");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Sesiones");
            DropTable("dbo.Respuestas");
            DropTable("dbo.Dificultades");
            DropTable("dbo.Conjuntos");
            DropTable("dbo.Preguntas");
            DropTable("dbo.Categorias");
        }
    }
}

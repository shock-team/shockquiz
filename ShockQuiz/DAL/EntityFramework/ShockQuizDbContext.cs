using System.Data.Entity;
using ShockQuiz.Dominio;

namespace ShockQuiz.DAL.EntityFramework
{
    class ShockQuizDbContext
    {
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

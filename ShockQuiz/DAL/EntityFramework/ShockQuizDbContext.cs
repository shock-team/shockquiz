using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ShockQuiz.DAL.EntityFramework
{
    class ShockQuizDbContext
    {
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Respuesta> Respuestas {get;set;}
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

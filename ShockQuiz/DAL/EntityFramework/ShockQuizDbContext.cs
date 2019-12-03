using System.Data.Entity;
using ShockQuiz.Dominio;

namespace ShockQuiz.DAL.EntityFramework
{
    class ShockQuizDbContext:DbContext
    {
        public ShockQuizDbContext() : base("ShockQuiz")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShockQuizDbContext, Migrations.Configuration>());
        }
        
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Dificultad> Dificultades { get; set; }
        public DbSet<Conjunto> Conjuntos { get; set; }

        protected override void OnModelCreating(DbModelBuilder pModelBuilder)
        {
            pModelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(pModelBuilder);
        }
    }
}

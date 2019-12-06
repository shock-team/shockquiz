using ShockQuiz.Dominio;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace ShockQuiz.DAL.EntityFramework
{
    public class ShockQuizDbContext : DbContext
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

        /// <summary>
        /// Guarda las entidades en la base de datos.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}

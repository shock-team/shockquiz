using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioDificultad : Repositorio<Dificultad, ShockQuizDbContext>
    {
        public RepositorioDificultad(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Dificultad> ObtenerTodas()
        {
            return this.iDbContext.Set<Dificultad>().ToList();
        }

        public Dificultad GetOrCreate(string pNombre)
        {
            var manager = ((IObjectContextAdapter)iDbContext).ObjectContext;

            var dbDificultad = from t in iDbContext.Dificultades
                               where t.Nombre == pNombre
                              select t;

            if (dbDificultad.Count() > 0)
            {
                return dbDificultad.First();
            }

            var cachedDificultad = manager.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
                                .Select(x => x.Entity)
                                .OfType<Dificultad>()
                                .SingleOrDefault(x => x.Nombre == pNombre);
            if (cachedDificultad != null)
            {
                return cachedDificultad;
            }

            Dificultad dificultad = new Dificultad()
            {
                Nombre = pNombre
            };
            return dificultad;
        }
    }
}

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
    public class RepositorioConjunto : Repositorio<Conjunto, ShockQuizDbContext>
    {
        public RepositorioConjunto(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Conjunto> ObtenerTodas()
        {
            return this.iDbContext.Set<Conjunto>();
        }

        public Conjunto Get(string pNombre)
        {
            var manager = ((IObjectContextAdapter)iDbContext).ObjectContext;

            var dbConjunto = from t in iDbContext.Conjuntos
                             where t.Nombre == pNombre
                             select t;

            if (dbConjunto.Count() > 0)
            {
                return dbConjunto.First();
            }

            var cachedConjunto = manager.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
                                .Select(x => x.Entity)
                                .OfType<Conjunto>()
                                .SingleOrDefault(x => x.Nombre == pNombre);
            if (cachedConjunto != null)
            {
                return cachedConjunto;
            }

            return null;
        }
    }
}

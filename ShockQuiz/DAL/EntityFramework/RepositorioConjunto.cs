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
        
        /// <summary>
        /// Devuelve todos los Conjuntos de la base de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Conjunto> ObtenerTodas()
        {
            return this.iDbContext.Set<Conjunto>().ToList();
        }

        /// <summary>
        /// Chequea si la categoria con <paramref name="pNombre"/> existe en la base de datos y la devuelve,
        /// sino cheque si existe en el caché de entidades de EF y la devuelve,
        /// sino devuelve nulo.
        /// </summary>
        /// <param name="pNombre">Nombre del Conjunto</param>
        /// <returns></returns>

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

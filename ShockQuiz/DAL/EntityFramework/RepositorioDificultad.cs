using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioDificultad : Repositorio<Dificultad, ShockQuizDbContext>
    {
        public RepositorioDificultad(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        /// <summary>
        /// Devuelve todas las Dificultades de la base de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Dificultad> ObtenerTodas()
        {
            return this.iDbContext.Set<Dificultad>().ToList();
        }

        /// <summary>
        /// Chequea si la dificultad con <paramref name="pNombre"/> existe en la base de datos y la devuelve,
        /// sino cheque si existe en el caché de entidades de EF y la devuelve,
        /// sino crea una nueva y la devuelve.
        /// </summary>
        /// <param name="pNombre">Nombre de la Dificultad</param>
        /// <returns></returns>
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

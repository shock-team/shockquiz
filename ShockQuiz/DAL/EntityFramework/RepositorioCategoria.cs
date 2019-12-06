using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioCategoria : Repositorio<Categoria, ShockQuizDbContext>
    {
        public RepositorioCategoria(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        /// <summary>
        /// Devuelve todas las Categorias de la base de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoria> ObtenerTodas()
        {
            return this.iDbContext.Set<Categoria>().ToList();
        }

        /// <summary>
        /// Chequea si la categoria con <paramref name="pNombre"/> existe en la base de datos y la devuelve,
        /// sino cheque si existe en el caché de entidades de EF y la devuelve,
        /// sino crea una nueva y la devuelve.
        /// </summary>
        /// <param name="pNombre">Nombre de la categoría</param>
        /// <returns></returns>
        public Categoria GetOrCreate(string pNombre)
        {
            var manager = ((IObjectContextAdapter)iDbContext).ObjectContext;

            var dbCategoria = from t in iDbContext.Categorias
                              where t.Nombre == pNombre
                              select t;

            if (dbCategoria.Count() > 0)
            {
                return dbCategoria.First();
            }

            var cachedCategoria = manager.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
                                .Select(x => x.Entity)
                                .OfType<Categoria>()
                                .SingleOrDefault(x => x.Nombre == pNombre);
            if (cachedCategoria != null)
            {
                return cachedCategoria;
            }

            Categoria categoria = new Categoria()
            {
                Nombre = pNombre
            };
            return categoria;
        }
    }
}

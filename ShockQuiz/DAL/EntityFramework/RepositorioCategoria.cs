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
    public class RepositorioCategoria:Repositorio<Categoria, ShockQuizDbContext>
    {
        public RepositorioCategoria(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Categoria> ObtenerTodas()
        {
            return this.iDbContext.Set<Categoria>();
        }

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

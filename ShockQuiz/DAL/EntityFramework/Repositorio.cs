using System;
using System.Data.Entity;

namespace ShockQuiz.DAL.EntityFramework
{
    abstract class Repositorio<TEntity, TDbContext> : IRepositorio<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext iDbContext;

        public Repositorio(TDbContext pDbContext)
        {
            if (pDbContext == null)
            {
                throw new ArgumentNullException(nameof(pDbContext));
            }

            this.iDbContext = pDbContext;
        }

        public void Agregar(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            iDbContext.Set<TEntity>().Add(pEntity);
        }

        public TEntity Obtener(string pNombre)
        {
            return this.iDbContext.Set<TEntity>().Find(pNombre);
        }
    }
}

using System;
using System.Data.Entity;

namespace ShockQuiz.DAL.EntityFramework
{
    public abstract class Repositorio<TEntity, TDbContext> : IRepositorio<TEntity>
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

        /// <summary>
        /// Agrega una entidad genérica a la base de datos.
        /// </summary>
        /// <param name="pEntity"></param>
        public void Agregar(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            iDbContext.Set<TEntity>().Add(pEntity);
        }

        /// <summary>
        /// Devuelve una entidad genérica de la base de datos a partir de su <paramref name="pId"/>
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public TEntity Obtener(int pId)
        {
            return this.iDbContext.Set<TEntity>().Find(pId);
        }

    }
}

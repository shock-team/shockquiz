using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ShockQuiz.DAL.EntityFramework
{
    abstract class Repositorio<TEntity, TDbContext> : IRepositorio<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        public void Agregar(TEntity pEntity)
        {
            throw new NotImplementedException();
        }

        public TEntity Obtener(string pNombre)
        {
            throw new NotImplementedException();
        }
    }
}

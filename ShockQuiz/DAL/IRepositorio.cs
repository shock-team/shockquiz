using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL
{
    public interface IRepositorio<TEntity>
        where TEntity : class
    {
        void Agregar(TEntity pEntity);
        TEntity Obtener(string pNombre);
    }
}

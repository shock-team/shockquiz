using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.Dominio;
using ShockQuiz.DAL.EntityFramework;

namespace ShockQuiz.Servicios
{
    public class ServiciosCategoria
    {
        /// <summary>
        /// Este método se utiliza para obtener todas las categorías presentes en la base de datos,
        /// según un conjunto.
        /// </summary>
        /// <param name="pIdConjunto">El ID del conjunto cuyas categorías se obtendrán.</param>
        /// <returns></returns>
        public static IEnumerable<Categoria> ObtenerCategorias(int pIdConjunto)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioPregunta.ObtenerCategorias(pIdConjunto);
                }
            }
        }
    }
}

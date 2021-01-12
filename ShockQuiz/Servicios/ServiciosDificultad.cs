using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.Dominio;
using ShockQuiz.DAL.EntityFramework;

namespace ShockQuiz.Servicios
{
    public class ServiciosDificultad
    {
        /// <summary>
        /// Este método se utiliza para obtener todas las dificultades presentes en la base de datos,
        /// según un conjunto.
        /// </summary>
        /// <param name="pIdConjunto">El ID del conjunto cuyas dificultades se obtienen.</param>
        /// <returns></returns>
        public static IEnumerable<Dificultad> ObtenerDificultades(int pIdConjunto)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioPregunta.ObtenerDificultades(pIdConjunto);
                }
            }
        }
    }
}

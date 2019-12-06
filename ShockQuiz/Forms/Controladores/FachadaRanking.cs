using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Forms
{
    class FachadaRanking
    {
        /// <summary>
        /// Devuelve una lista de las <paramref name="pTop"/> mejores sesiones, ordenadas según puntaje
        /// </summary>
        /// <param name="pTop">Cantidad de sesiones a mostrar en el ranking</param>
        /// <returns></returns>
        public List<Sesion> ObtenerTop(int pTop = 15)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioSesion.ObtenerRanking(pTop).ToList();
                }
            }
        }
    }
}

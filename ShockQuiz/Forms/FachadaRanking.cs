using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Forms
{
    class FachadaRanking
    {
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

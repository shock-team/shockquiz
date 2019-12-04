using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.DAL;
using ShockQuiz.Dominio;
using ShockQuiz.DAL.EntityFramework;

namespace ShockQuiz.Forms
{
    public class FachadaConfigurarSesion
    {
        public IEnumerable<Conjunto> ObtenerConjuntos()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioConjunto.ObtenerTodas();
                }
            }
        }

        public IEnumerable<Categoria> ObtenerCategorias(int pConjuntoId)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioPregunta.ObtenerCategorias(pConjuntoId);
                }
            }
        }

        public IEnumerable<Dificultad> ObtenerDificultades()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioDificultad.ObtenerTodas();
                }
            }
        }
    }
}

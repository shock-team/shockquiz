using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.Dominio;
using ShockQuiz.DAL;
using ShockQuiz.DAL.EntityFramework;

namespace ShockQuiz.Forms
{
    class FachadaConfiguracionAdmin
    {
        public bool AdminAUsuario(string pUsuario)
        {
            bool resultado = false;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    resultado  = bUoW.RepositorioUsuario.Descender(pUsuario);
                }
            }
            return resultado;
        }

        public bool UsuarioAAdmin(string pUsuario)
        {
            bool resultado = false;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    resultado = bUoW.RepositorioUsuario.Ascender(pUsuario);
                }
            }
            return resultado;
        }

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
    }
}

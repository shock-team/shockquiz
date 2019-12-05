using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.Dominio;
using ShockQuiz.DAL;
using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.DAL.OpenTriviaDB;

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

        public void AñadirConjunto(string pNombre, int pTEPP, bool token)
        {

            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    string tokenString = null;
                    if (token)
                    {
                        tokenString = JsonMapper.ObtenerToken();
                    }

                    Conjunto otdb = new ConjuntoOTDB()
                    {
                        Nombre = pNombre,
                        TiempoEsperadoPorPregunta = pTEPP,
                        Token = tokenString
                    };
                    bUoW.RepositorioConjunto.Agregar(otdb);
                    bUoW.GuardarCambios();
                }
            }
        }


    }
}

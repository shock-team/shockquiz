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
        /// <summary>
        /// Reduce la autoridad de un administrador a usuario
        /// </summary>
        /// <param name="pUsuario">El administrador</param>
        /// <returns></returns>
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

        /// <summary>
        /// Incrementa la autoridad de un usuario a administrador
        /// </summary>
        /// <param name="pUsuario">El usuario</param>
        /// <returns></returns>
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

        /// <summary>
        /// Devuelve los conjuntos presentes en la base de datos de la aplicación
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Crea una nueva instancia de ConjuntoOTDB y la guarda en la base de datos
        /// </summary>
        /// <param name="pNombre">Nombre del nuevo ConjuntoOTDB</param>
        /// <param name="pTEPP">Cantidad de sengudos esperada por pregunta</param>
        /// <param name="token">Si el checkbox del Token fue seleccionado o no</param>
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

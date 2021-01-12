using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.Dominio;
using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Excepciones;
using ShockQuiz.DAL.OpenTriviaDB;

namespace ShockQuiz.Servicios
{
    public class ServiciosConjunto
    {
        /// <summary>
        /// Devuelve los conjuntos presentes en la base de datos de la aplicación
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Conjunto> ObtenerConjuntos()
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
        /// <param name="pTipoConjunto">El tipo del conjunto a crear.</param>
        public static void AñadirConjunto(string pNombre, int pTEPP, bool token, Type pTipoConjunto)
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
                    Conjunto conjunto = (Conjunto)Activator.CreateInstance(pTipoConjunto);
                    conjunto.Nombre = pNombre;
                    conjunto.TiempoEsperadoPorPregunta = pTEPP;
                    conjunto.Token = tokenString;

                    bUoW.RepositorioConjunto.Agregar(conjunto);
                    bUoW.GuardarCambios();
                }
            }
        }

        public static Conjunto ObtenerConjunto(int pIdConjunto)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioConjunto.Obtener(pIdConjunto);
                }
            }
        }
    }
}

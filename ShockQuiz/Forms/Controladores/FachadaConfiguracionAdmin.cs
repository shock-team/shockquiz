using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.Dominio;
using ShockQuiz.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShockQuiz.Forms
{
    public class FachadaConfiguracionAdmin
    {
        /// <summary>
        /// Incrementa la autoridad de un usuario a administrador
        /// </summary>
        /// <param name="pUsuario">El usuario</param>
        /// <returns></returns>
        public void UsuarioAAdmin(string pUsuario)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.RepositorioUsuario.Ascender(pUsuario);
                    bUoW.GuardarCambios();
                }
            }
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

        /// <summary>
        /// Este método se utiliza para eliminar los datos almacenados actualmente
        /// en la base de datos.
        /// </summary>
        public void LimpiarDB()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bDbContext.Set<Respuesta>().RemoveRange(bDbContext.Set<Respuesta>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Pregunta>().RemoveRange(bDbContext.Set<Pregunta>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Sesion>().RemoveRange(bDbContext.Set<Sesion>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Usuario>().RemoveRange(bDbContext.Set<Usuario>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Categoria>().RemoveRange(bDbContext.Set<Categoria>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Conjunto>().RemoveRange(bDbContext.Set<Conjunto>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Dificultad>().RemoveRange(bDbContext.Set<Dificultad>());
                    bUoW.GuardarCambios();
                }
            }
        }

        public void AlmacenarPreguntas(List<Pregunta> pPreguntas, IProgress<ProgressReportModel> progress, int pCantidad, int pNumCalls)
        {
            ProgressReportModel report = new ProgressReportModel();
            int aux = 50 * pNumCalls;

            using (var bDbContext =  new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (var pregunta in pPreguntas)
                    {
                        aux++;

                        string preguntaDesc = pregunta.Nombre;
                        string CONJUNTO = pregunta.ConjuntoNombre;
                        pregunta.Nombre = bUoW.RepositorioPregunta.GetOrCreate(preguntaDesc, CONJUNTO);

                        string categoria = pregunta.Categoria.Nombre;
                        pregunta.Categoria = bUoW.RepositorioCategoria.GetOrCreate(categoria);

                        string dificultad = pregunta.Dificultad.Nombre;
                        pregunta.Dificultad = bUoW.RepositorioDificultad.GetOrCreate(dificultad);

                        pregunta.Conjunto = bUoW.RepositorioConjunto.Get(CONJUNTO);

                        if (pregunta.Nombre != string.Empty)
                        {
                            bUoW.RepositorioPregunta.Agregar(pregunta);
                        }

                        report.PercentageComplete = (aux * 100) / (pCantidad + 50 * pNumCalls);
                        progress.Report(report);
                    }
                    bUoW.GuardarCambios();
                }
            }
        }
    }
}

using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Forms
{
    public class FachadaConfigurarSesion
    {
        /// <summary>
        /// Devuelve una lista con el nombre de todos los conjuntos presentes en la base de
        /// datos de la aplicación
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
        /// Devuelve los nombres de las categorías de las preguntas de un conjunto especificado.
        /// </summary>
        /// <param name="pConjunto">Nombre del conjunto de preguntas</param>
        /// <returns></returns>
        public IEnumerable<Categoria> ObtenerCategorias(int pConjunto)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioPregunta.ObtenerCategorias(pConjunto);
                }
            }
        }

        /// <summary>
        /// Devuelve el las dificultades de las preguntas presentes en la base de datos
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Crea y devuelve una nueva sesión de preguntas a partir de los parámetros seleccionados,
        /// obteniendo sus instancias de la base de datos.
        /// </summary>
        /// <param name="pUsuario">Id del usuario de la sesión</param>
        /// <param name="pCategoria">La categoría de las preguntas</param>
        /// <param name="pDificultad">La dificultad</param>
        /// <param name="pCantidad">Cantidad de preguntas de la sesión</param>
        /// <param name="pConjunto">Conjunto del que se obtienen las preguntas de la sesión</param>
        /// <returns></returns>
        public Sesion IniciarSesion(int pUsuario, int pCategoria, int pDificultad, int pCantidad, int pConjunto)
        {
            Sesion sesion = new Sesion();
            sesion.FechaInicio = DateTime.Now;
            sesion.CategoriaId = pCategoria;
            sesion.DificultadId = pDificultad;
            sesion.ConjuntoId = pConjunto;
            sesion.CantidadPreguntas = pCantidad;
            sesion.UsuarioId = pUsuario;
            sesion.FechaFin = DateTime.Parse("01-01-2399");
            sesion.SesionFinalizada = false;

            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    sesion.Usuario = bUoW.RepositorioUsuario.Obtener(pUsuario);
                    sesion.Conjunto = bUoW.RepositorioConjunto.Obtener(pConjunto);
                    sesion.Categoria = bUoW.RepositorioCategoria.Obtener(pCategoria);
                    sesion.Dificultad = bUoW.RepositorioDificultad.Obtener(pDificultad);

                    bUoW.RepositorioSesion.Agregar(sesion);
                    bUoW.GuardarCambios();

                    int idSesion = bUoW.RepositorioSesion.ObtenerUltimaSesion().SesionId;
                    IEnumerable<Pregunta> listaDePreguntas = bUoW.RepositorioPregunta.ObtenerPreguntas(pCategoria, pDificultad, pConjunto, pCantidad);
                    foreach (Pregunta pregunta in listaDePreguntas)
                    {
                        pregunta.SesionActualId = idSesion;
                    }
                    bUoW.GuardarCambios();
                }
            }
            return sesion;
        }

        public void GuardarSesion(Sesion pSesion)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    pSesion.Categoria = null;
                    pSesion.Conjunto = null;
                    pSesion.Dificultad = null;
                    pSesion.Usuario = null;
                    bUoW.RepositorioSesion.Agregar(pSesion);
                    bUoW.GuardarCambios();
                }
            }
        }
    }
}

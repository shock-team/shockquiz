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
        /// <param name="pCategoria">Id de la categoría de las preguntas</param>
        /// <param name="pDificultad">Id de la dificultad</param>
        /// <param name="pCantidad">Cantidad de preguntas de la sesión</param>
        /// <param name="pConjunto">Id del conjunto del que se obtienen las preguntas de la sesión</param>
        /// <returns></returns>
        public Sesion IniciarSesion(int pUsuario, int pCategoria, int pDificultad, int pCantidad, int pConjunto)
        {
            Sesion sesion = new Sesion();
            sesion.FechaInicio = DateTime.Now;
            sesion.CategoriaId = pCategoria;
            sesion.DificultadId = pDificultad;
            sesion.ConjuntoId = pConjunto;
            sesion.PreguntasRestantes = pCantidad;
            sesion.CantidadTotalPreguntas = pCantidad;
            sesion.UsuarioId = pUsuario;
            sesion.FechaFin = DateTime.Parse("01-01-2399");
            sesion.SesionFinalizada = false;
            sesion.SegundosTranscurridos = 0;

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

                    IEnumerable<Pregunta> listaDePreguntas = bUoW.RepositorioPregunta.ObtenerPreguntas(pCategoria, pDificultad, pConjunto, pCantidad);
                    foreach (Pregunta pregunta in listaDePreguntas)
                    {
                        pregunta.SesionActualId = sesion.SesionId;
                    }
                    bUoW.GuardarCambios();
                }
            }
            return sesion;
        }
    }
}

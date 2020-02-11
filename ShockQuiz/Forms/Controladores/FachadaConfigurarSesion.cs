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
        public Sesion IniciarSesion(int pUsuario, Categoria pCategoria, Dificultad pDificultad, int pCantidad, Conjunto pConjunto)
        {
            Sesion sesion = new Sesion();
            Usuario usuario;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    usuario = bUoW.RepositorioUsuario.Obtener(pUsuario);
                    sesion.Usuario = usuario;
                    sesion.UsuarioId = usuario.UsuarioId;
                    sesion.Preguntas = bUoW.RepositorioPregunta.ObtenerPreguntas(pCategoria, pDificultad, pConjunto, pCantidad).ToList();
                }
            }
            sesion.FechaInicio = DateTime.Now;
            sesion.Categoria = pCategoria;
            sesion.CategoriaId = pCategoria.Id;
            sesion.Dificultad = pDificultad;
            sesion.DificultadId = pDificultad.Id;
            sesion.Conjunto = pConjunto;
            sesion.ConjuntoId = pConjunto.ConjuntoId;
            sesion.CantidadPreguntas = pCantidad;
            return sesion;
        }
    }
}

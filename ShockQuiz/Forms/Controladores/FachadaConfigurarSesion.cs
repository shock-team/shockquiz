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
        public IEnumerable<string> ObtenerConjuntos()
        {
            List<string> conjuntos = new List<string>();
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (Conjunto conjunto in bUoW.RepositorioConjunto.ObtenerTodas())
                    {
                        conjuntos.Add(conjunto.Nombre);
                    }
                }
            }
            return conjuntos;
        }

        /// <summary>
        /// Devuelve los nombres de las categorías de las preguntas de un conjunto especificado.
        /// </summary>
        /// <param name="pConjunto">Nombre del conjunto de preguntas</param>
        /// <returns></returns>
        public IEnumerable<string> ObtenerCategorias(string pConjunto)
        {
            List<string> categorias = new List<string>();
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (Categoria categoria in bUoW.RepositorioPregunta.ObtenerCategorias(pConjunto))
                    {
                        categorias.Add(categoria.Nombre);
                    }
                }
            }
            return categorias;
        }

        /// <summary>
        /// Devuelve el nombre de las dificultades de las preguntas presentes en la base de datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ObtenerDificultades()
        {
            List<string> dificultades = new List<string>();
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (Dificultad dificultad in bUoW.RepositorioDificultad.ObtenerTodas())
                    {
                        dificultades.Add(dificultad.Nombre);
                    }
                }
            }
            return dificultades;
        }

        /// <summary>
        /// Crea y devuelve una nueva sesión de preguntas a partir de los parámetros seleccionados,
        /// obteniendo sus instancias de la base de datos.
        /// </summary>
        /// <param name="pUsuario">Nombre del usuario de la sesión</param>
        /// <param name="pCategoria">Nombre de la categoría de las preguntas</param>
        /// <param name="pDificultad">Nombre de la dificultad</param>
        /// <param name="pCantidad">Cantidad de preguntas de la sesión</param>
        /// <param name="pConjunto">Conjunto del que se obtienen las preguntas de la sesión</param>
        /// <returns></returns>
        public Sesion IniciarSesion(string pUsuario, string pCategoria, string pDificultad, int pCantidad, string pConjunto)
        {
            Sesion sesion = new Sesion();
            Usuario usuario;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    usuario = bUoW.RepositorioUsuario.Obtener(pUsuario);
                }
            }
            sesion.Usuario = usuario;
            sesion.UsuarioId = usuario.UsuarioId;
            sesion.FechaInicio = DateTime.Now;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Categoria categoria = bUoW.RepositorioCategoria.ObtenerTodas().Where(x => x.Nombre == pCategoria).Single();
                    sesion.Categoria = categoria;
                    sesion.CategoriaId = categoria.Id;
                    Dificultad dificultad = bUoW.RepositorioDificultad.ObtenerTodas().Where(x => x.Nombre == pDificultad).Single();
                    sesion.Dificultad = dificultad;
                    sesion.DificultadId = dificultad.Id;
                    Conjunto conjunto = bUoW.RepositorioConjunto.ObtenerTodas().Where(x => x.Nombre == pConjunto).Single();
                    sesion.Conjunto = conjunto;
                    sesion.ConjuntoId = conjunto.ConjuntoId;
                    sesion.Preguntas = bUoW.RepositorioPregunta.ObtenerPreguntas(categoria, dificultad, conjunto, pCantidad).ToList();
                }
            }
            sesion.CantidadPreguntas = pCantidad;
            return sesion;
        }
    }
}

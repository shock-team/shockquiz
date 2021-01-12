using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using ShockQuiz.Servicios;

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
            return ServiciosConjunto.ObtenerConjuntos();
        }

        /// <summary>
        /// Devuelve los nombres de las categorías de las preguntas de un conjunto especificado.
        /// </summary>
        /// <param name="pConjunto">Nombre del conjunto de preguntas</param>
        /// <returns></returns>
        public IEnumerable<Categoria> ObtenerCategorias(int pConjunto)
        {
            return ServiciosCategoria.ObtenerCategorias(pConjunto);
        }


        /// <summary>
        /// Devuelve el las dificultades de las preguntas presentes en la base de datos, según un
        /// conjunto.
        /// </summary>
        /// <param name="pIdConjunto">ID del conjunto.</param>
        /// <returns></returns>
        public IEnumerable<Dificultad> ObtenerDificultades(int pIdConjunto)
        {
            return ServiciosDificultad.ObtenerDificultades(pIdConjunto);
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
        public int IniciarSesion(int pUsuario, int pCategoria, int pDificultad, int pCantidad, int pConjunto)
        {
            return ServiciosSesion.IniciarSesion(pUsuario, pConjunto, pDificultad, pCategoria, pCantidad);
        }
    }
}

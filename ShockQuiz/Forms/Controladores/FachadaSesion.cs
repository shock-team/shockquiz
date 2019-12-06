using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using ShockQuiz.IO;
using System;

namespace ShockQuiz
{
    public class FachadaSesion
    {
        /// <summary>
        /// El objetivo de esta clase es funcionar como intermediario entre la interfaz gráfica
        /// correspondiente a la sesión de preguntas, y las clases con las que se interactúa.
        /// </summary>
        public Sesion iSesionActual { get; set; }
        public Conjunto iConjunto { get; set; }

        /// <summary>
        /// Devuelve un PreguntaDTO correspondiente a la siguiente de la sesión
        /// </summary>
        /// <returns></returns>
        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            return iSesionActual.ObtenerPreguntaYRespuestas();
        }

        /// <summary>
        ///Devuelve el resultado de responder a una pregunta
        /// </summary>
        /// <param name="pRespuesta">La respuesta seleccionada por el usuario</param>
        /// <returns></returns>
        public ResultadoRespuesta Responder(string pRespuesta)
        {
            ResultadoRespuesta resultado = iSesionActual.Responder(pRespuesta);
            return resultado;
        }

        /// <summary>
        /// Devuelve un resultado al verificar que la sesión actual no se exceda del tiempo límite
        /// </summary>
        /// <returns></returns>
        public ResultadoRespuesta RevisarTiempoLimite()
        {
            double tiempo = iSesionActual.TiempoLimite();
            ResultadoRespuesta resultado = new ResultadoRespuesta();
            resultado.FinSesion = false;
            if ((DateTime.Now - iSesionActual.FechaInicio).TotalSeconds > tiempo)
            {
                for (int i = iSesionActual.Preguntas.Count; i > 0; i--)
                {
                    resultado = iSesionActual.Responder("");
                }
                resultado.TiempoLimiteFinalizado = true;
            }
            return resultado;
        }

        /// <summary>
        /// Devuelve el puntaje de la sesión actual
        /// </summary>
        /// <returns></returns>
        public double ObtenerPuntaje()
        {
            return iSesionActual.Puntaje;
        }

        /// <summary>
        /// Guarda la sesión actual en la base datos
        /// </summary>
        public void GuardarSesion()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    this.iSesionActual.Categoria = null;
                    this.iSesionActual.Conjunto = null;
                    this.iSesionActual.Dificultad = null;
                    this.iSesionActual.Usuario = null;
                    bUoW.RepositorioSesion.Agregar(this.iSesionActual);
                    bUoW.GuardarCambios();
                }
            }
        }
    }
}

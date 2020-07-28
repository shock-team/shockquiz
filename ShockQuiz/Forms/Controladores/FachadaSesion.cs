using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using ShockQuiz.IO;
using ShockQuiz.DAL;
using System;
using System.Windows.Forms;

namespace ShockQuiz
{
    /// <summary>
    /// El objetivo de esta clase es funcionar como intermediario entre la interfaz gráfica
    /// correspondiente a la sesión de preguntas, y las clases con las que se interactúa.
    /// </summary>
    public class FachadaSesion
    {
        public Sesion iSesionActual { get; set; }
        public int tiempoRestante { get; set; }

        public FachadaSesion()
        {
            tiempoRestante = RepositorioSesionActiva.TiempoRestante();
        }

        /// <summary>
        /// Devuelve un PreguntaDTO correspondiente a la siguiente de la sesión
        /// </summary>
        /// <returns></returns>
        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            PreguntaDTO preguntaYRespuestas = new PreguntaDTO();
            preguntaYRespuestas.Pregunta = iSesionActual.ObtenerPregunta();
            preguntaYRespuestas.Respuestas = iSesionActual.ObtenerRespuestas();
            return preguntaYRespuestas;
        }

        /// <summary>
        ///Devuelve el resultado de responder a una pregunta y actualiza el tiempo restante
        ///en el archivo temporal de sesion activa.
        /// </summary>
        /// <param name="pRespuesta">La respuesta seleccionada por el usuario</param>
        /// <returns></returns>
        public ResultadoRespuesta Responder(string pRespuesta)
        {
            ResultadoRespuesta resultado = iSesionActual.Responder(pRespuesta);
            iSesionActual.TiempoRestante = tiempoRestante;
            RepositorioSesionActiva.GuardarSesionActiva(iSesionActual);
            return resultado;
        }

        /// <summary>
        /// Devuelve un resultado al verificar que la sesión actual no se exceda del tiempo límite
        /// </summary>
        /// <returns></returns>
        public ResultadoRespuesta RevisarTiempoLimite(int pTiempo)
        {
            double tiempo = pTiempo;
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
        /// Guarda la sesión actual en la base datos y elimina el archivo temporal de la sesion aun no finalizada
        /// </summary>
        public void GuardarSesion()
        {
            RepositorioSesionActiva.EliminarSesionActiva();
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

        /// <summary>
        /// Si existe una sesión activa devuelve el tiempo restante de la misma, sino,
        /// lo calcula y devuelve normalmente.
        /// </summary>
        /// <returns></returns>
        public int ObtenerTiempoLimite()
        {
            if (RepositorioSesionActiva.ExisteSesionActiva() && tiempoRestante != 0)
            {
                return tiempoRestante;
            }
            else
            {
                return (int)iSesionActual.TiempoLimite();
            }
        }
    }
}

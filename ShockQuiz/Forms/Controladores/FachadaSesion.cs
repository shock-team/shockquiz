using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using ShockQuiz.Forms;
using ShockQuiz.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using ShockQuiz.Servicios;

namespace ShockQuiz
{
    /// <summary>
    /// El objetivo de esta clase es funcionar como intermediario entre la interfaz gráfica
    /// correspondiente a la sesión de preguntas, y las clases con las que se interactúa.
    /// </summary>
    public class FachadaSesion
    {
        public AyudanteTimer ayudanteTimer { get; set; }

        /// <summary>
        /// Inicia el temporizador y devuelve un PreguntaDTO correspondiente a la siguiente de la sesión
        /// </summary>
        /// <param name="pOnTimeFinishedHandler">La acción a realizar cuando se agota el tiempo límite</param>
        /// <param name="pOnTickTimer">La acción a realizar por cada tick</param>
        /// <param name="pIdSesionActual">El ID de la sesión actual</param>
        /// <returns></returns>
        public PreguntaDTO ObtenerPreguntaYRespuestas(Action pOnTimeFinishedHandler, Action<int> pOnTickTimer, int pIdSesionActual)
        {
            Random random = new Random();
            PreguntaDTO preguntaYRespuestas = new PreguntaDTO();
            Sesion sesionActual = ServiciosSesion.ObtenerSesion(pIdSesionActual);
            Pregunta pregunta = ServiciosPregunta.ObtenerPregunta(sesionActual.ObtenerIdSiguientePregunta());

            int tiempoRestante = Convert.ToInt32(sesionActual.TiempoLimite() - sesionActual.SegundosTranscurridos);
            ayudanteTimer = new AyudanteTimer(tiempoRestante, pOnTimeFinishedHandler, pOnTickTimer);

            preguntaYRespuestas.IdPregunta = pregunta.PreguntaId;
            preguntaYRespuestas.Pregunta = pregunta.Nombre;

            RespuestaDTO respuestaActualDTO;
            List<RespuestaDTO> listaDeRespuestas = new List<RespuestaDTO>();
            foreach (Respuesta respuesta in pregunta.Respuestas)
            {
                respuestaActualDTO = new RespuestaDTO();
                respuestaActualDTO.IdRespuesta = respuesta.RespuestaId;
                respuestaActualDTO.Respuesta = respuesta.DefRespuesta;
                listaDeRespuestas.Add(respuestaActualDTO);
            }

            preguntaYRespuestas.Respuestas = listaDeRespuestas.OrderBy(x => random.Next()).ToList();

            return preguntaYRespuestas;
        }

        /// <summary>
        ///Devuelve el resultado de responder a una pregunta
        /// </summary>
        /// <param name="pIdSesionActual">El ID de la sesión actual</param>
        /// <param name="pIdPregunta">El ID de la pregunta a responder</param>
        /// <param name="pIdRespuesta">El ID de la respuesta seleccionada por el usuario</param>
        /// <returns></returns>
        public ResultadoRespuesta Responder(int pIdSesionActual, int pIdPregunta, int pIdRespuesta)
        {
            DetenerTimer();
            ResultadoRespuesta resultado = ServiciosPregunta.Responder(pIdPregunta, pIdRespuesta);
            resultado.FinSesion = ServiciosSesion.Responder(pIdSesionActual, ayudanteTimer.TiempoTranscurrido, resultado.EsCorrecta);
            return resultado;
        }

        /// <summary>
        /// Devuelve un resultado al verificar que la sesión actual no se exceda del tiempo límite
        /// </summary>
        /// <param name="pIdSesionActual">El ID de la sesión actual</param>
        public void FinTiempoLimite(int pIdSesionActual)
        {
            ServiciosSesion.CancelarSesion(pIdSesionActual);
        }

        /// <summary>
        /// Devuelve el puntaje de la sesión actual
        /// </summary>
        /// <param name="pIdSesionActual">El ID de la sesión actual</param>
        /// <returns></returns>
        public double ObtenerPuntaje(int pIdSesionActual)
        {
            Sesion sesionActual = ObtenerSesion(pIdSesionActual);
            return sesionActual.Puntaje;
        }

        /// <summary>
        /// Este método se utiliza para detener el timer activo
        /// </summary>
        public void DetenerTimer()
        {
            ayudanteTimer.bgWorker.CancelAsync();
        }

        /// <summary>
        /// Éste método se utiliza para obtener una sesión en particular presente en la base de datos.
        /// </summary>
        /// <param name="pIdSesionActual">El ID de la sesión.</param>
        /// <returns></returns>
        public Sesion ObtenerSesion(int pIdSesionActual)
        {
            return ServiciosSesion.ObtenerSesion(pIdSesionActual);
        }
    }
}

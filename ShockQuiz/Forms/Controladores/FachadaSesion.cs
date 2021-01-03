using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using ShockQuiz.IO;
using ShockQuiz.Forms;
using System.Linq;
using System;
using System.Collections.Generic;

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
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Random random = new Random();
                    PreguntaDTO preguntaYRespuestas = new PreguntaDTO();
                    Sesion sesionActual = bUoW.RepositorioSesion.ObtenerSesionId(pIdSesionActual);
                    Pregunta pregunta = bUoW.RepositorioPregunta.ObtenerPreguntaPorId(sesionActual.ObtenerIdSiguientePregunta());

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

                    int tiempoRestante = Convert.ToInt32(sesionActual.TiempoLimite() - sesionActual.SegundosTranscurridos);
                    ayudanteTimer = new AyudanteTimer(tiempoRestante, pOnTimeFinishedHandler, pOnTickTimer);

                    return preguntaYRespuestas;
                }
            }            
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
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.ObtenerSesionId(pIdSesionActual);

                    Respuesta respuestaCorrecta = bUoW.RepositorioPregunta.ObtenerRespuestaCorrecta(pIdPregunta);

                    ResultadoRespuesta resultado = new ResultadoRespuesta();
                    resultado.EsCorrecta = (respuestaCorrecta.RespuestaId == pIdRespuesta);
                    resultado.RespuestaCorrecta = respuestaCorrecta.DefRespuesta;
                    resultado.FinSesion = sesionActual.Responder(resultado.EsCorrecta);

                    DetenerTimer();
                    sesionActual.SegundosTranscurridos += ayudanteTimer.TiempoTranscurrido;
                    bUoW.GuardarCambios();
                    return resultado;
                }
            }        
        }

        /// <summary>
        /// Devuelve un resultado al verificar que la sesión actual no se exceda del tiempo límite
        /// </summary>
        /// <param name="pIdSesionActual">El ID de la sesión actual</param>
        public void FinTiempoLimite(int pIdSesionActual)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.Obtener(pIdSesionActual);
                    sesionActual.SesionFinalizada = true;
                    int idPreguntaActual;
                    foreach (Pregunta pregunta in sesionActual.Preguntas)
                    {
                        idPreguntaActual = sesionActual.ObtenerIdSiguientePregunta();
                        Responder(sesionActual.SesionId, pregunta.PreguntaId, 0);
                    }

                    bUoW.GuardarCambios();
                }
            }
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
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.ObtenerSesionId(pIdSesionActual);
                    return sesionActual;
                }
            }
        }
    }
}

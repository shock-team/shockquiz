﻿using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using ShockQuiz.IO;
using ShockQuiz.Forms;

namespace ShockQuiz
{
    /// <summary>
    /// El objetivo de esta clase es funcionar como intermediario entre la interfaz gráfica
    /// correspondiente a la sesión de preguntas, y las clases con las que se interactúa.
    /// </summary>
    public class FachadaSesion
    {
        public int idSesionActual { get; set; }
        public AyudanteTimer ayudanteTimer { get; set; }

        /// <summary>
        /// Devuelve un PreguntaDTO correspondiente a la siguiente de la sesión
        /// </summary>
        /// <returns></returns>
        public PreguntaDTO ObtenerPreguntaYRespuestas()
        { 
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.Obtener(idSesionActual);
                    PreguntaDTO preguntaYRespuestas = new PreguntaDTO();
                    int idPregunta = sesionActual.ObtenerPregunta();
                    Pregunta pregunta = bUoW.RepositorioPregunta.Obtener(idPregunta);
                    preguntaYRespuestas.Pregunta = pregunta.Nombre;
                    preguntaYRespuestas.Respuestas = pregunta.ObtenerRespuestas();
                    return preguntaYRespuestas;
                }
            }            
        }

        /// <summary>
        ///Devuelve el resultado de responder a una pregunta
        /// </summary>
        /// <param name="pRespuesta">La respuesta seleccionada por el usuario</param>
        /// <returns></returns>
        public ResultadoRespuesta Responder(string pRespuesta)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    ResultadoRespuesta resultado;
                    Sesion sesionActual = bUoW.RepositorioSesion.Obtener(idSesionActual);
                    int idPregunta = sesionActual.ObtenerPregunta();
                    Pregunta pregunta = bUoW.RepositorioPregunta.Obtener(idPregunta);
                    resultado = pregunta.Responder(pRespuesta);
                    resultado.FinSesion = sesionActual.Responder(resultado.EsCorrecta);
                    return resultado;
                }
            }        
        }

        /// <summary>
        /// Devuelve un resultado al verificar que la sesión actual no se exceda del tiempo límite
        /// </summary>
        /// <returns></returns>
        public void FinTiempoLimite()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.Obtener(idSesionActual);
                    while (sesionActual.CantidadPreguntas > 0)
                    {
                        Responder("");
                    }
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Devuelve el puntaje de la sesión actual
        /// </summary>
        /// <returns></returns>
        public double ObtenerPuntaje()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.Obtener(idSesionActual);
                    return sesionActual.Puntaje;
                }
            }
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
                    Sesion sesionActual = bUoW.RepositorioSesion.Obtener(idSesionActual);
                    sesionActual.SegundosTranscurridos += ayudanteTimer.TiempoTranscurrido;
                    bUoW.GuardarCambios();
                }
            }
        }

        public void IniciarTimer()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.Obtener(idSesionActual);
                    ayudanteTimer = new AyudanteTimer(System.Convert.ToInt32(sesionActual.TiempoLimite() - sesionActual.SegundosTranscurridos));
                }
            }
        }
    }
}

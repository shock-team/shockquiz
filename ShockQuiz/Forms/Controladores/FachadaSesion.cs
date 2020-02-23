using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using ShockQuiz.IO;
using System;

namespace ShockQuiz
{
    /// <summary>
    /// El objetivo de esta clase es funcionar como intermediario entre la interfaz gráfica
    /// correspondiente a la sesión de preguntas, y las clases con las que se interactúa.
    /// </summary>
    public class FachadaSesion
    {
        public int iSesionId { get; set; }
        public string iPreguntasId { get; set; }

        /// <summary>
        /// Devuelve un PreguntaDTO correspondiente a la siguiente de la sesión
        /// </summary>
        /// <returns></returns>
        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            PreguntaDTO preguntaYRespuestas = new PreguntaDTO();
            int idPregunta = int.Parse(iPreguntasId.Substring(0, iPreguntasId.IndexOf("-")));
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Pregunta pregunta = bUoW.RepositorioPregunta.Obtener(idPregunta);
                    preguntaYRespuestas.Pregunta = pregunta.Nombre;
                    preguntaYRespuestas.Respuestas = pregunta.ObtenerRespuestas();
                }
            }

            return preguntaYRespuestas;
        }

        /// <summary>
        ///Devuelve el resultado de responder a una pregunta
        /// </summary>
        /// <param name="pRespuesta">La respuesta seleccionada por el usuario</param>
        /// <returns></returns>
        public ResultadoRespuesta Responder(string pRespuesta)
        {
            int idPregunta = int.Parse(iPreguntasId.Substring(0, iPreguntasId.IndexOf("-")));
            iPreguntasId = iPreguntasId.Substring(iPreguntasId.IndexOf("-") + 1, iPreguntasId.Length);
            ResultadoRespuesta resultado;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Pregunta pregunta = bUoW.RepositorioPregunta.Obtener(idPregunta);
                    resultado = pregunta.Responder(pRespuesta);
                    Sesion sesion = bUoW.RepositorioSesion.Obtener(iSesionId);
                    resultado.FinSesion=sesion.Actualizar(resultado.EsCorrecta, iPreguntasId);
                    bUoW.GuardarCambios();
                }
            }
            return resultado;
        }

        /// <summary>
        /// Devuelve un resultado al verificar que la sesión actual no se exceda del tiempo límite
        /// </summary>
        /// <returns></returns>
        public ResultadoRespuesta RevisarTiempoLimite()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    ResultadoRespuesta resultado = new ResultadoRespuesta();
                    Sesion sesionActual = bUoW.RepositorioSesion.Obtener(iSesionId);
                    if (sesionActual.RevisarTiempoLimite())
                    {
                        while (sesionActual.CantidadPreguntas > 0)
                        {
                            Responder("");
                        }
                        resultado.FinSesion = true;
                    }
                    else
                    {
                        resultado.FinSesion = false;
                    }
                    return resultado;
                }
            }
        }

        /// <summary>
        /// Devuelve el puntaje de la sesión actual
        /// </summary>
        /// <returns></returns>
        public double ObtenerPuntaje()
        {
            Sesion sesion;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    sesion = bUoW.RepositorioSesion.Obtener(iSesionId);
                }

            }
            return sesion.Puntaje;
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
                    bUoW.GuardarCambios();
                }
            }
        }
    }
}

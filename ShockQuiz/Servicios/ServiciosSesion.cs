using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.Dominio;
using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Excepciones;


namespace ShockQuiz.Servicios
{
    public class ServiciosSesion
    {
        /// <summary>
        /// Este método se utiliza para obtener el ID de la sesión activa de un usuario.
        /// </summary>
        /// <param name="pIdUsuario">El ID del usuario.</param>
        /// <returns></returns>
        public static int ObtenerSesionActiva(int pIdUsuario)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.ObtenerSesionActiva(pIdUsuario);
                    if (sesionActual == null)
                    {
                        return -1;
                    }
                    else
                    {
                        return sesionActual.SesionId;
                    }
                }
            }
        }

        /// <summary>
        /// Este método se encarga de cancelar una sesión que se encuentre activa.
        /// </summary>
        /// <param name="pIdSesion">El ID de la sesión a cancelar.</param>
        public static void CancelarSesion(int pIdSesion)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActiva = bUoW.RepositorioSesion.ObtenerSesionId(pIdSesion);
                    sesionActiva.FechaFin = DateTime.Now;
                    foreach (Pregunta pregunta in sesionActiva.Preguntas.ToList())
                    {
                        sesionActiva.Responder(false, pregunta.PreguntaId);
                    }
                    sesionActiva.SesionFinalizada = true;
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para crear y persistir una nueva sesión en la base de datos,
        /// devolviendo su ID.
        /// </summary>
        /// <param name="pUsuario">El ID del usuario correspondiente a la nueva sesión.</param>
        /// <param name="pListaDePreguntas">Las preguntas asociadas a la nueva sesión.</param>
        /// <returns></returns>
        public static int IniciarSesion(int pUsuario, int pConjunto, int pDificultad, int pCategoria, int pCantidad)
        {
            Random random = new Random();
            Sesion sesion = new Sesion();
            sesion.FechaInicio = DateTime.Now;
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
                    sesion.Preguntas = bUoW.RepositorioPregunta.ObtenerPreguntas(pCategoria, pDificultad, pConjunto, pCantidad).ToList();
                    bUoW.RepositorioSesion.Agregar(sesion);
                    bUoW.GuardarCambios();
                }
            }
            return sesion.SesionId;
        }

        /// <summary>
        /// Devuelve una lista de las <paramref name="pTop"/> mejores sesiones, ordenadas según puntaje
        /// </summary>
        /// <param name="pTop">Cantidad de sesiones a mostrar en el ranking</param>
        /// <returns></returns>
        public static List<Sesion> ObtenerTop(int pTop = 15)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioSesion.ObtenerRanking(pTop).ToList();
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para obtener una sesión presente en la base de datos
        /// a partir de su ID.
        /// </summary>
        /// <param name="pIdSesion">El ID de la sesión a obtener.</param>
        /// <returns></returns>
        public static Sesion ObtenerSesion(int pIdSesion)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioSesion.ObtenerSesionId(pIdSesion);
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para actualizar los datos de una sesión existente en la base
        /// de datos al responder una pregunta.
        /// </summary>
        /// <param name="pIdSesion">El ID de la sesión.</param>
        /// <param name="pSegundosTranscurridos">Los segundos transcurridos hasta la respuesta.</param>
        /// <param name="pEsCorrecta">Si la respuesta fue correcta o no.</param>
        /// <returns></returns>
        public static bool Responder(int pIdSesion, double pSegundosTranscurridos, bool pEsCorrecta, int pIdPregunta)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActual = bUoW.RepositorioSesion.ObtenerSesionId(pIdSesion);
                    sesionActual.SegundosTranscurridos += pSegundosTranscurridos;
                    bool resultado = sesionActual.Responder(pEsCorrecta, pIdPregunta);
                    bUoW.GuardarCambios();
                    return resultado;
                }
            }
        }
    }
}

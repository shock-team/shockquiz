using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using ShockQuiz.IO;
using System;
using System.Linq;

namespace ShockQuiz
{
    public class Fachada
    {
        private Sesion iSesionActual { get; set; }
        public int iCantidadPreguntas { get; set; }

        public void IniciarSesion(Usuario pUsuario, Categoria pCategoria, Dificultad pDificultad, int pCantidad, Conjunto pConjunto)
        {
            iSesionActual = new Sesion();
            iSesionActual.Usuario = pUsuario;
            iSesionActual.Categoria = pCategoria;
            iSesionActual.Dificultad = pDificultad;
            iSesionActual.FechaInicio = DateTime.Now;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork())
                {
                    iSesionActual.Preguntas = bUoW.RepositorioPreguntas.ObtenerPreguntas(pCategoria, pDificultad, pConjunto, pCantidad).ToList();
                }
            }
        }

        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            return iSesionActual.ObtenerPreguntaYRespuestas();
        }

        public ResultadoRespuesta Responder(string pRespuesta)
        {
            ResultadoRespuesta resultado = iSesionActual.Responder(pRespuesta);
            if (resultado.FinSesion)
            {
                using (var bDbContext = new ShockQuizDbContext())
                {
                    using (UnitOfWork bUoW = new UnitOfWork())
                    {
                        bUoW.RepositorioSesion.Agregar(iSesionActual);
                    }
                }
            }
            return resultado;
        }

        public double ObtenerPuntaje()
        {
            return iSesionActual.Puntaje;
        }
    }
}

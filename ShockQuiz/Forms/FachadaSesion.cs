using System;
using System.Collections.Generic;
using ShockQuiz.Dominio;
using ShockQuiz.IO;
using ShockQuiz.DAL.EntityFramework;
using System.Linq;
using System.Windows.Forms;

namespace ShockQuiz
{
    public class FachadaSesion
    {
        private Sesion iSesionActual { get; set; }
        public Conjunto iConjunto { get; set; }

        public void IniciarSesion(string pUsuario, Categoria pCategoria, Dificultad pDificultad, int pCantidad, Conjunto pConjunto)
        {
            iSesionActual = new Sesion();
            Usuario usuario;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    usuario = bUoW.RepositorioUsuario.Obtener(pUsuario);
                }
            }
            iSesionActual.Usuario = usuario;
            iSesionActual.Categoria = pCategoria;
            iSesionActual.Dificultad = pDificultad;
            iSesionActual.FechaInicio = DateTime.Now;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    iSesionActual.Preguntas = bUoW.RepositorioPregunta.ObtenerPreguntas(pCategoria, pDificultad, pConjunto, pCantidad).ToList();
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
                    using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                    {
                        bUoW.RepositorioSesion.Agregar(iSesionActual);
                    }
                }
            }
            return resultado;
        }

        public ResultadoRespuesta RevisarTiempoLimite()
        {
            double tiempo = iSesionActual.TiempoLimite();
            ResultadoRespuesta resultado = new ResultadoRespuesta();
            resultado.FinSesion = false;
            if ((DateTime.Now - iSesionActual.FechaInicio).TotalSeconds > tiempo)
            {
                foreach (Pregunta pregunta in iSesionActual.Preguntas)
                {
                    resultado = iSesionActual.Responder("");
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

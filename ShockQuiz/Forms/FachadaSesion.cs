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

        public void IniciarSesion(string pUsuario, string pCategoria, string pDificultad, int pCantidad, string pConjunto)
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
            iSesionActual.UsuarioId = usuario.UsuarioId;
            iSesionActual.FechaInicio = DateTime.Now;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Categoria categoria = bUoW.RepositorioCategoria.ObtenerTodas().Where(x => x.Nombre == pCategoria).Single();
                    iSesionActual.Categoria = categoria;
                    iSesionActual.CategoriaId = categoria.Id;
                    Dificultad dificultad = bUoW.RepositorioDificultad.ObtenerTodas().Where(x => x.Nombre == pDificultad).Single();
                    iSesionActual.Dificultad = dificultad;
                    iSesionActual.DificultadId = dificultad.Id;
                    Conjunto conjunto = bUoW.RepositorioConjunto.ObtenerTodas().Where(x => x.Nombre == pConjunto).Single();
                    iSesionActual.Conjunto = conjunto;
                    iSesionActual.ConjuntoId = conjunto.ConjuntoId;
                    iSesionActual.Preguntas = bUoW.RepositorioPregunta.ObtenerPreguntas(categoria, dificultad, conjunto, pCantidad).ToList();
                }
            }
            iSesionActual.CantidadPreguntas = pCantidad;
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

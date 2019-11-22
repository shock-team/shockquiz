using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Dominio
{
    public class Sesion
    {
        private int SesionId { get; }
        private int CantidadPreguntas { get; }
        private Categoria Categoria { get; }
        private Dificultad Dificultad { get; }
        private double Puntaje { get; set; }
        private DateTime FechaInicio;
        private DateTime FechaFin;
        private Usuario Usuario { get; }
        private List<Pregunta> Preguntas;
        private int RespuestasCorrectas = 0;

        public Sesion(int pCantidadPreguntas, Categoria pCategoria, Dificultad pDificultad, double pPuntaje, DateTime pFecha, DateTime pFechaFin, Usuario pUsuario, List<Pregunta> pPreguntas)
        {
            this.CantidadPreguntas = pCantidadPreguntas;
            this.Categoria = pCategoria;
            this.Dificultad = pDificultad;
            this.Puntaje = pPuntaje;
            this.FechaInicio = pFecha;
            this.FechaFin = pFechaFin;
            this.Usuario = pUsuario;
            this.Preguntas = pPreguntas;
        }



        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            return Preguntas.First().ObtenerPreguntaYRespuestas();
        }

        public ResultadoRespuesta Responder(string pRespuesta)
        {
            Pregunta pregunta = Preguntas.First();
            ResultadoRespuesta resultado = pregunta.Responder(pRespuesta);
            if (resultado.iEsCorrecta)
            {
                RespuestasCorrectas++;
            }
            Preguntas.Remove(pregunta);
            if (Preguntas.Count() == 0)
            {
                resultado.iFinSesion = true;
                Finalizar();
            }
            return resultado;
        }

        public TimeSpan Duracion()
        {
            return FechaFin - FechaInicio;
        }

        public void Finalizar()
        {
            double factorTiempo = 1;
            double factorDificultad = 1;
            this.FechaFin = DateTime.Now;
            Puntaje = (RespuestasCorrectas / CantidadPreguntas) * factorTiempo * factorDificultad;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ShockQuiz.IO;

namespace ShockQuiz.Dominio
{
    public class Sesion
    {
<<<<<<< HEAD
        public int SesionId { get; set; }
        public int CantidadPreguntas { get; set; }
        public Categoria Categoria { get; set; }
        public Dificultad Dificultad { get; set; }
        public double Puntaje { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Usuario Usuario { get; set; }
        public IList<Pregunta> Preguntas { get; set; }
        public int RespuestasCorrectas = 0;
=======
        public int SesionId { get; }
        public int CantidadPreguntas { get; }
        public Categoria Categoria { get; }
        public Dificultad Dificultad { get; }
        public double Puntaje { get; set; }
        public DateTime FechaInicio;
        public DateTime FechaFin;
        public Usuario Usuario { get; }
        public List<Pregunta> Preguntas;
        public int RespuestasCorrectas = 0;

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


>>>>>>> 4ac8bb843540e464c3f787cb553c39f65231cecc

        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            return Preguntas.First().ObtenerPreguntaYRespuestas();
        }

        public ResultadoRespuesta Responder(string pRespuesta)
        {
            Pregunta pregunta = Preguntas.First();
            ResultadoRespuesta resultado = pregunta.Responder(pRespuesta);
            if (resultado.EsCorrecta)
            {
                RespuestasCorrectas++;
            }
            Preguntas.Remove(pregunta);
            if (Preguntas.Count() == 0)
            {
                resultado.FinSesion = true;
                Finalizar();
            }
            return resultado;
        }



        public void Finalizar()
        {
            double factorTiempo = 1;
            double factorDificultad = Dificultad.Multiplicador;
            this.FechaFin = DateTime.Now;
            Puntaje = (RespuestasCorrectas / CantidadPreguntas) * factorTiempo * factorDificultad;
        }
    }
}

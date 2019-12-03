using System;
using System.Collections.Generic;
using System.Linq;
using ShockQuiz.IO;

namespace ShockQuiz.Dominio
{
    public class Sesion
    {
        public int SesionId { get; }
        public int CantidadPreguntas { get; set; }
        public Categoria Categoria { get; set; }
        public Dificultad Dificultad { get; set; }
        public double Puntaje { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Usuario Usuario { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public int RespuestasCorrectas = 0;

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

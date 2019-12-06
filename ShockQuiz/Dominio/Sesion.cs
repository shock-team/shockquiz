using ShockQuiz.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Dominio
{
    public class Sesion
    {
        public int SesionId { get; set; }
        public int CantidadPreguntas { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int DificultadId { get; set; }
        public Dificultad Dificultad { get; set; }
        public double Puntaje { get; set; } = 0;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Conjunto Conjunto { get; set; }
        public int ConjuntoId { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public int RespuestasCorrectas { get; set; } = 0;

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
                this.FechaFin = DateTime.Now;
                this.Puntaje = Conjunto.CalcularPuntaje(this);
            }
            return resultado;
        }

        public TimeSpan Duracion()
        {
            return FechaFin - FechaInicio;
        }

        public double TiempoLimite()
        {
            return CantidadPreguntas * Conjunto.TiempoEsperadoPorPregunta;
        }
    }
}

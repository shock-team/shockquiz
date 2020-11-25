using ShockQuiz.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Dominio
{
    public class Sesion
    {
        public int SesionId { get; set; }
        public int PreguntasRestantes { get; set; }
        public int CantidadTotalPreguntas { get; set; }
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
        public int RespuestasCorrectas { get; set; } = 0;
        public double SegundosTranscurridos { get; set; }
        public bool SesionFinalizada { get; set; }

        /// <summary>
        /// Este método se utiliza para modificar los datos de la sesión
        /// según se haya respondido correctamente o no.
        /// </summary>
        /// <param name="pEsCorrecta">Si la respuesta dada a la pregunta fue correcta</param>
        /// <returns></returns>
        public bool Responder(bool pEsCorrecta)
        {
            bool finSesion = false;
            PreguntasRestantes--;
            if (pEsCorrecta)
            {
                RespuestasCorrectas++;
            }
            if (PreguntasRestantes <= 0)
            {
                finSesion = true;
                this.FechaFin = DateTime.Now;
                this.Puntaje = Conjunto.CalcularPuntaje(this);
            }
            this.SesionFinalizada = finSesion;
            return finSesion;
        }

        /// <summary>
        /// Este método se utiliza para obtener el tiempo límite de la sesión
        /// </summary>
        /// <returns></returns>
        public double TiempoLimite()
        {
            return CantidadTotalPreguntas * Conjunto.TiempoEsperadoPorPregunta;
        }
    }
}

using ShockQuiz.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Dominio
{
    public class Sesion
    {
        public int SesionId { get; set; }
        public int CantidadTotalPreguntas { get; set; }
        public double Puntaje { get; set; } = 0;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public int RespuestasCorrectas { get; set; } = 0;
        public double SegundosTranscurridos { get; set; }
        public bool SesionFinalizada { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; } = new List<Pregunta>();

        /// <summary>
        /// Este método se utiliza para modificar los datos de la sesión
        /// según se haya respondido correctamente o no.
        /// </summary>
        /// <param name="pEsCorrecta">Si la respuesta dada a la pregunta fue correcta</param>
        /// <returns></returns>
        public bool Responder(bool pEsCorrecta, int pIdPregunta)
        {
            bool finSesion = false;
            Pregunta pregunta = Preguntas.Where(x => x.PreguntaId == pIdPregunta).FirstOrDefault();

            if (pEsCorrecta)
            {
                RespuestasCorrectas++;
            }
            if (Preguntas.Count == 1)
            {
                finSesion = true;
                this.FechaFin = DateTime.Now;
                this.Puntaje = pregunta.Conjunto.CalcularPuntaje(this);
            }

            pregunta.QuitarDeSesion(SesionId);
            Preguntas.Remove(pregunta);

            this.SesionFinalizada = finSesion;
            return finSesion;
        }

        /// <summary>
        /// Este método se utiliza para obtener el tiempo límite de la sesión
        /// </summary>
        /// <returns></returns>
        public double TiempoLimite()
        {
            double tiempoLimite = 0;
            if (Preguntas.Count > 0)
            {
                tiempoLimite = CantidadTotalPreguntas * Preguntas.First().Conjunto.TiempoEsperadoPorPregunta;
            }
            return tiempoLimite;
        }

        /// <summary>
        /// Este método se utiliza para obtener la siguiente pregunta correspondiente a la sesión.
        /// </summary>
        /// <returns></returns>
        public int ObtenerIdSiguientePregunta()
        {
            return Preguntas.OrderBy(x => Guid.NewGuid()).First().PreguntaId;
        }

        /// <summary>
        /// Este método se utiliza para obtener los nombres de la Categoría y la Dificultad 
        /// correspondientes a la sesión.
        /// </summary>
        /// <returns></returns>
        public NombresDatos ObtenerNombres()
        {
            NombresDatos nombresDatos = new NombresDatos();
            if (Preguntas.Count > 0)
            {
                Pregunta pregunta = Preguntas.First();
                nombresDatos.Categoria = pregunta.Categoria.Nombre;
                nombresDatos.Dificultad = pregunta.Dificultad.Nombre;
            }
            return nombresDatos;
        }
    }
}

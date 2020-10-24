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
        public ICollection<Pregunta> Preguntas { get; set; }
        public int RespuestasCorrectas { get; set; } = 0;
<<<<<<< Updated upstream
        public string PreguntasString { get; set; }
=======
        public int SegundosTranscurridos { get; set; }
>>>>>>> Stashed changes

        public List<string> ObtenerRespuestas()
        {
            return Preguntas.First().ObtenerRespuestas();
        }

        public string ObtenerPregunta()
        {
            return Preguntas.First().Nombre;
        }

        public bool Actualizar(bool pEsCorrecta, string pPreguntas)
        {
            bool finSesion = false;
            CantidadPreguntas--;
            if (pEsCorrecta)
            {
                RespuestasCorrectas++;
            }

            if (CantidadPreguntas == 0)
            {
                finSesion = true;
                this.FechaFin = DateTime.Now;
                this.Puntaje = Conjunto.CalcularPuntaje(this);
            }
            return finSesion;
        }

        public ResultadoRespuesta RevisarTiempoLimite(int pTiempo)
        {
            ResultadoRespuesta resultado = new ResultadoRespuesta();
            resultado.FinSesion = (pTiempo > TiempoLimite());
            return resultado;
        }

        public double TiempoLimite()
        {
            return CantidadPreguntas * Conjunto.TiempoEsperadoPorPregunta;
        }

        /// <summary>
        /// Devuelve un resultado al verificar que la sesión actual no se exceda del tiempo límite
        /// </summary>
        /// <returns></returns>
        public bool RevisarTiempoLimite()
        {
            double tiempo = TiempoLimite();
            return (DateTime.Now - FechaInicio).TotalSeconds > tiempo;
        }
    }
}

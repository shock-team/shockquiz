using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    abstract public class Conjunto
    {
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public double tiempoEsperadoPorPregunta { get; set; }
        public ICollection<Sesion> Sesiones { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }

        public abstract double CalcularPuntaje(Sesion pSesion);
    }
}

using System;
using System.Collections.Generic;

namespace ShockQuiz.Dominio
{
    public abstract class Conjunto
    {
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public double TiempoEsperadoPorPregunta { get; set; }
        public string Token { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }

        /// <summary>
        /// Este método se utiliza para calcular el puntaje de una Sesión, según las reglas
        /// del conjunto.
        /// </summary>
        /// <param name="pSesion">La sesión cuyo puntaje debe obtenerse.</param>
        /// <returns></returns>
        public virtual double CalcularPuntaje(Sesion pSesion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método se utiliza para obtener una lista de preguntas, cuyo origen dependerá
        /// del conjunto.
        /// </summary>
        /// <param name="pCantidad">La cantidad de preguntas a obtener.</param>
        /// <returns></returns>
        public virtual List<Pregunta> ObtenerPreguntas(int pCantidad)
        {
            throw new NotImplementedException();
        }
    }
}

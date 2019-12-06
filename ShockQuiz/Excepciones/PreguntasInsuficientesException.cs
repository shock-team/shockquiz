using System;

namespace ShockQuiz.Excepciones
{
    class PreguntasInsuficientesException : Exception
    {
        public PreguntasInsuficientesException() : base("La cantidad de preguntas es insuficiente") { }
    }
}

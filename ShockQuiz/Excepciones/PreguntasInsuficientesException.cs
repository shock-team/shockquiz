using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Excepciones
{
    class PreguntasInsuficientesException : Exception
    {
        public PreguntasInsuficientesException() : base("La cantidad de preguntas es insuficiente") { }
    }
}

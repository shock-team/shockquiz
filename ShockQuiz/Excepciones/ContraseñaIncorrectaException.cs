using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Excepciones
{
    class ContraseñaIncorrectaException : Exception
    {
        public ContraseñaIncorrectaException() : base("Contraseña incorrecta") { }
    }
}

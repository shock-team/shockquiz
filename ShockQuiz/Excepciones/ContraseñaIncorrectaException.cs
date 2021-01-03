using System;

namespace ShockQuiz.Excepciones
{
    class ContraseñaIncorrectaException : Exception
    {
        public ContraseñaIncorrectaException() : base("Contraseña incorrecta") { }
    }
}

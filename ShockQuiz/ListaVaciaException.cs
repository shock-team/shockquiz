using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    class ListaVaciaException : Exception
    {
        public ListaVaciaException() : base("No quedan más elementos") { }
    }
}

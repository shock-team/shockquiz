using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    class Usuario
    {
        private string iNombre { get; }
        private string iContraseña { get; }

        public Usuario(string pNombre, string pContraseña)
        {
            this.iNombre = pNombre;
            this.iContraseña = pContraseña;
        }
    }
}

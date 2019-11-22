using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public class Usuario
    {
        private int UsuarioId { get; }
        private string Nombre { get; }
        private string Contraseña { get; }

        public Usuario(string pNombre, string pContraseña)
        {
            this.Nombre = pNombre;
            this.Contraseña = pContraseña;
        }
    }
}

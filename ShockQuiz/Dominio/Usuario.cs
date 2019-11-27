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
        public string Nombre { get; }
        private string Contraseña { get; }
        public bool Admin { get; set; }

        public Usuario(string pNombre, string pContraseña)
        {
            this.Nombre = pNombre;
            this.Contraseña = pContraseña;
            this.Admin = false;
        }
    }
}

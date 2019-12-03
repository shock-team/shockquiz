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
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool Admin { get; set; }

        public Usuario(string pNombre, string pContraseña)
        public bool ContraseñaCorrecta(string pPass)
        {
            this.Nombre = pNombre;
            this.Contraseña = pContraseña;
            this.Admin = false;
            if (pPass == this.Contraseña)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

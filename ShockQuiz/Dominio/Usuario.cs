using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool Admin { get; set; }
        public ICollection<Sesion> Sesiones { get; set; }

        public bool ContraseñaCorrecta(string pPass)
        {
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

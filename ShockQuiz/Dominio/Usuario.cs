using System.Collections.Generic;

namespace ShockQuiz.Dominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool Admin { get; set; }
        public ICollection<Sesion> Sesiones { get; set; }

        /// <summary>
        /// Este método se utiliza para comprobar si la contraseña escrita
        /// es la correcta para este usuario.
        /// </summary>
        /// <param name="pPass">La contraseña escrita</param>
        /// <returns></returns>
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

using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioUsuario:Repositorio<Usuario, ShockQuizDbContext>, IRepositorioUsuario
    {
        public RepositorioUsuario(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        /// <summary>
        /// Convierte el Usuario con <paramref name="pNombre"/> como administrador.
        /// </summary>
        /// <param name="pNombre">Nombre del Usuario</param>
        /// <returns></returns>
        public bool Ascender(string pNombre)
        {
            Usuario user = this.iDbContext.Set<Usuario>().Find(pNombre);
            if (user != null)
            {
                user.Admin = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Quita privilegios de administrador al Usuario <paramref name="pNombre"/>.
        /// </summary>
        /// <param name="pNombre">Nombre del Usuario</param>
        /// <returns></returns>
        public bool Descender(string pNombre)
        {
            Usuario user = this.iDbContext.Set<Usuario>().Find(pNombre);
            if (user != null)
            {
                user.Admin = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve todos los Usuarios de la base de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> ObtenerTodos()
        {
            return this.iDbContext.Set<Usuario>();
        }

        /// <summary>
        /// Devuelve el Usuario a partir de su <paramref name="pNombre"/>.
        /// </summary>
        /// <param name="pNombre"></param>
        /// <returns></returns>
        public Usuario Obtener(string pNombre)
        {
            return this.iDbContext.Set<Usuario>().First(x => x.Nombre == pNombre);
        }
    }
}

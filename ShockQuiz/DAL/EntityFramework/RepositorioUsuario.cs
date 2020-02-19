using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioUsuario : Repositorio<Usuario, ShockQuizDbContext>, IRepositorioUsuario
    {
        public RepositorioUsuario(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        /// <summary>
        /// Convierte el Usuario con <paramref name="pNombre"/> como administrador.
        /// </summary>
        /// <param name="pNombre">Nombre del Usuario</param>
        /// <returns></returns>
        public void Ascender(string pNombre)
        {
            Usuario user = ObtenerPorNombre(pNombre);
            user.Admin = true;
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
        public Usuario ObtenerPorNombre(string pNombre)
        {
            return this.iDbContext.Set<Usuario>().First(x => x.Nombre == pNombre);
        }
    }
}

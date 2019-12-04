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

        public IEnumerable<Usuario> ObtenerTodos()
        {
            return this.iDbContext.Set<Usuario>();
        }

        public Usuario Obtener(string pNombre)
        {
            return this.iDbContext.Set<Usuario>().First(x => x.Nombre == pNombre);
        }
    }
}

using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    class RepositorioUsuario:Repositorio<Usuario, ShockQuizDbContext>, IRepositorioUsuario
    {
        public RepositorioUsuario(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public void Ascender(string pNombre)
        {
            Usuario user = this.iDbContext.Set<Usuario>().Find(pNombre);
            user.Admin = true;
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            return this.iDbContext.Set<Usuario>();
        }
    }
}

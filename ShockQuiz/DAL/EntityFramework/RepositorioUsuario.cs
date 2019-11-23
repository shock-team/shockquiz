using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    class RepositorioUsuario:Repositorio<Sesion, ShockQuizDbContext>, IRepositorioUsuario
    {
        public RepositorioUsuario(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public void Agregar(Usuario pEntity)
        {
            throw new NotImplementedException();
        }

        public void Ascender(string pNombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        Usuario IRepositorio<Usuario>.Obtener(string pNombre)
        {
            throw new NotImplementedException();
        }
    }
}

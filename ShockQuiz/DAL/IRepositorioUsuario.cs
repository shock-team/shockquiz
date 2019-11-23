using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace ShockQuiz.DAL
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        void Ascender(string pNombre);
        IEnumerable<Usuario> ObtenerTodos();
    }
}

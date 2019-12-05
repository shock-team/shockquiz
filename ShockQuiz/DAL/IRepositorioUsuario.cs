using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace ShockQuiz.DAL
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        bool Ascender(string pNombre);
        bool Descender(string pNombre);
        IEnumerable<Usuario> ObtenerTodos();
        Usuario Obtener(string pNombre);
    }
}

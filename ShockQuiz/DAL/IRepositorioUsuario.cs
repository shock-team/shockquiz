using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        void Ascender(string pNombre);
        IEnumerable<Usuario> ObtenerTodos();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL
{
    public interface IUnitOfWork
    {
        void Save();
        IRepositorioPregunta RepositorioPreguntas { get; }
        IRepositorioUsuario RepositorioUsuarios { get; }
        IRepositorioSesion RepositorioSesion { get; }
    }
}

using System;

namespace ShockQuiz.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void GuardarCambios();
        IRepositorioPregunta RepositorioPreguntas { get; }
        IRepositorioUsuario RepositorioUsuarios { get; }
        IRepositorioSesion RepositorioSesion { get; }
    }
}

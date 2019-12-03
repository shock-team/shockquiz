using System;

namespace ShockQuiz.DAL
{
<<<<<<< HEAD
    public interface IUnitOfWork : IDisposable
=======
    public interface IUnitOfWork:IDisposable
>>>>>>> 4ac8bb843540e464c3f787cb553c39f65231cecc
    {
        void GuardarCambios();
        IRepositorioPregunta RepositorioPreguntas { get; }
        IRepositorioUsuario RepositorioUsuarios { get; }
        IRepositorioPregunta RepositorioPregunta { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioSesion RepositorioSesion { get; }
    }
}

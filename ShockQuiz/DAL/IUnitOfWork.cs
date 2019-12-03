using System;

namespace ShockQuiz.DAL
{
    public interface IUnitOfWork:IDisposable
    {
        void GuardarCambios();
        IRepositorioPregunta RepositorioPregunta { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioSesion RepositorioSesion { get; }
    }
}

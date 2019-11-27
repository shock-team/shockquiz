namespace ShockQuiz.DAL
{
    public interface IUnitOfWork
    {
        void GuardarCambios();
        IRepositorioPregunta RepositorioPreguntas { get; }
        IRepositorioUsuario RepositorioUsuarios { get; }
        IRepositorioSesion RepositorioSesion { get; }
    }
}

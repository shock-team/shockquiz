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

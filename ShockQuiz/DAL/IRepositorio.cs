namespace ShockQuiz.DAL
{
    public interface IRepositorio<TEntity>
        where TEntity : class
    {
        void Agregar(TEntity pEntity);
        TEntity Obtener(string pNombre);
    }
}

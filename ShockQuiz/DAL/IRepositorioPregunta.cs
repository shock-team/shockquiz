using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace ShockQuiz.DAL
{
    public interface IRepositorioPregunta : IRepositorio<Pregunta>

    {
        void AgregarConjunto(IEnumerable<Pregunta> pEntity);
        IEnumerable<Pregunta> ObtenerPreguntas(string pCategoria, string pDificultad);
        IEnumerable<Pregunta> GetAll();
    }
}

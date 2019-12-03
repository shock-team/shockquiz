using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace ShockQuiz.DAL
{
    public interface IRepositorioPregunta : IRepositorio<Pregunta>

    {
        void AgregarConjunto(IEnumerable<Pregunta> pConjunto);
        IEnumerable<Pregunta> ObtenerPreguntas(Categoria pCategoria, Dificultad pDificultad, Conjunto pConjunto, int pCantidad);
        IEnumerable<Pregunta> ObtenerTodas();
    }
}

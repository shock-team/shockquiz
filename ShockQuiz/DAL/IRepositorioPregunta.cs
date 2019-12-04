using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace ShockQuiz.DAL
{
    public interface IRepositorioPregunta : IRepositorio<Pregunta>

    {
        void AgregarPreguntas(IEnumerable<Pregunta> pPreguntas);
        IEnumerable<Pregunta> ObtenerPreguntas(Categoria pCategoria, Dificultad pDificultad, Conjunto pConjunto, int pCantidad);
        IEnumerable<Pregunta> ObtenerTodas();
        IEnumerable<Categoria> ObtenerCategorias(int pConjuntoId);
    }
}

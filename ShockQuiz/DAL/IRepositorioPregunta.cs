using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace ShockQuiz.DAL
{
    public interface IRepositorioPregunta : IRepositorio<Pregunta>

    {
        void AgregarPreguntas(IEnumerable<Pregunta> pPreguntas);
        string ObtenerPreguntas(Categoria pCategoria, Dificultad pDificultad, Conjunto pConjunto, int pCantidad);
        IEnumerable<Pregunta> ObtenerTodas();
        string GetOrCreate(string pNombre, string pConjunto);
        IEnumerable<Categoria> ObtenerCategorias(int pConjunto);
    }
}

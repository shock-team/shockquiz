using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace ShockQuiz.DAL
{
    public interface IRepositorioPregunta : IRepositorio<Pregunta>

    {
        void AgregarPreguntas(IEnumerable<Pregunta> pPreguntas);
        IEnumerable<Pregunta> ObtenerPreguntas(int pCategoria, int pDificultad, int pConjunto, int pCantidad);
        IEnumerable<Pregunta> ObtenerTodas();
        string GetOrCreate(string pNombre, string pConjunto);
        IEnumerable<Categoria> ObtenerCategorias(int pConjunto);
        IEnumerable<Pregunta> ObtenerPreguntasPorSesion(int pIdSesion);
        Pregunta ObtenerPreguntaPorId(int pIdPregunta);
        Respuesta ObtenerRespuestaCorrecta(int pIdPregunta);
    }
}

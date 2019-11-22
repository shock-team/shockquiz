using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL
{
    public interface IRepositorioPregunta:IRepositorio<Pregunta>

    { 
        void AgregarConjunto(IEnumerable<Pregunta> pEntity);
        IEnumerable<Pregunta> ObtenerPreguntas(string pCategoria, string pDificultad);
        IEnumerable<Pregunta> GetAll();
    }
}

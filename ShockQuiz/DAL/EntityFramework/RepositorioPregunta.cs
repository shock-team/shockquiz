using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    class RepositorioPregunta:Repositorio<Pregunta, ShockQuizDbContext>, IRepositorioPregunta
    {
        public RepositorioPregunta(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public void AgregarConjunto(IEnumerable<Pregunta> pEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pregunta> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pregunta> ObtenerPreguntas(string pCategoria, string pDificultad)
        {
            throw new NotImplementedException();
        }
    }
}

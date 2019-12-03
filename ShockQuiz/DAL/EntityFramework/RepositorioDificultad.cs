using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    class RepositorioDificultad : Repositorio<Dificultad, ShockQuizDbContext>
    {
        public RepositorioDificultad(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Dificultad> ObtenerTodas()
        {
            return this.iDbContext.Set<Dificultad>();
        }
    }
}

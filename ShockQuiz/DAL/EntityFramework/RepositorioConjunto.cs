using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioConjunto : Repositorio<Conjunto, ShockQuizDbContext>
    {
        public RepositorioConjunto(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Conjunto> ObtenerTodas()
        {
            return this.iDbContext.Set<Conjunto>();
        }
    }
}

using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    class RepositorioConjunto : Repositorio<Conjunto, ShockQuizDbContext>
    {
        public RepositorioConjunto(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Conjunto> ObtenerTodas(string pUsuario)
        {
            return this.iDbContext.Set<Conjunto>();
        }
    }
}

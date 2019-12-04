using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioDificultad : Repositorio<Dificultad, ShockQuizDbContext>
    {
        public RepositorioDificultad(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Dificultad> ObtenerTodas(string pUsuario)
        {
            return this.iDbContext.Set<Dificultad>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.DAL;
using ShockQuiz.Dominio;

namespace ShockQuiz.DAL.EntityFramework
{
    class RepositorioSesion:Repositorio<Sesion, ShockQuizDbContext>, IRepositorioSesion
    {
        public RepositorioSesion(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Sesion> ObtenerRanking(int pTop)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sesion> ObtenerTodas(string pUsuario)
        {
            throw new NotImplementedException();
        }
    }
}

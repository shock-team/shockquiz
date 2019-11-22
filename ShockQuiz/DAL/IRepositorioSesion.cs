using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL
{
    public interface IRepositorioSesion:IRepositorio<Sesion>
    {
        IEnumerable<Sesion> ObtenerTodas(string pUsuario);
        IEnumerable<Sesion> ObtenerRanking(int pTop);
    }
}

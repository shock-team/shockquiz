using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace ShockQuiz.DAL
{
    public interface IRepositorioSesion : IRepositorio<Sesion>
    {
        IEnumerable<Sesion> ObtenerTodas(string pUsuario);
        IEnumerable<Sesion> ObtenerRanking(int pTop);
        Sesion ObtenerSesionActiva();
        Sesion ObtenerSesionId(int pIdSesion);
    }
}

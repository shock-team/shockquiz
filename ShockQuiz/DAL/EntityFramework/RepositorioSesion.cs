using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioSesion : Repositorio<Sesion, ShockQuizDbContext>, IRepositorioSesion
    {
        public RepositorioSesion(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        /// <summary>
        /// Devuelve un <paramref name="pTop"/> de Sesiones ordenadas por puntaje.
        /// </summary>
        /// <param name="pTop"></param>
        /// <returns></returns>
        public IEnumerable<Sesion> ObtenerRanking(int pTop = 15)
        {
            List<Sesion> aux = new List<Sesion>();
            aux = this.iDbContext.Set<Sesion>().OrderByDescending(x => x.Puntaje).Take(pTop).ToList();
            foreach (var item in aux)
            {
                var user = from t in iDbContext.Usuarios
                           where t.UsuarioId == item.UsuarioId
                           select t;
                item.Usuario = user.First();
            }
            return aux;
        }

        /// <summary>
        /// Devuelve todas las Sesiones de la base de datos.
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public IEnumerable<Sesion> ObtenerTodas(string pUsuario)
        {
            return this.iDbContext.Set<Sesion>().Where(x => x.Usuario.Nombre == pUsuario);
        }

        /// <summary>
        /// Devuelve la sesion que se encuentre activa de un usuario específico en la base de datos.
        /// </summary>
        /// <param name="pIdUsuario">El ID del usuario cuya sesión activa se busca.</param>
        /// <returns></returns>
        public Sesion ObtenerSesionActiva(int pIdUsuario)
        {
            var sesionActiva = from s in iDbContext.Sesiones
                               .Include("Preguntas")
                               .Include("Preguntas.Conjunto")
                               .Include("Preguntas.Dificultad")
                               .Include("Preguntas.Categoria")
                               .Include("Preguntas.Sesiones")
                               where !s.SesionFinalizada && s.UsuarioId == pIdUsuario
                               select s;
            if (sesionActiva.Count() > 0)
            {
                return sesionActiva.First();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Este método se utiliza para obtener una sesión de la base de datos
        /// a partir de su ID, así como su conjunto y dificultad.
        /// </summary>
        /// <param name="pIdSesion">El ID de la sesión a traer</param>
        /// <returns></returns>
        public Sesion ObtenerSesionId(int pIdSesion)
        {
            var sesionActiva = from s in iDbContext.Sesiones
                               .Include("Preguntas")
                               .Include("Preguntas.Conjunto")
                               .Include("Preguntas.Dificultad")
                               .Include("Preguntas.Categoria")
                               .Include("Preguntas.Sesiones")
                               where s.SesionId == pIdSesion
                               select s;
            return sesionActiva.First();
        }
    }
}

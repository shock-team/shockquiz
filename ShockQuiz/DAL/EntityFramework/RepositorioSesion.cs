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

<<<<<<< Updated upstream
        public bool ExisteSesionNoFinalizada(int pUsuarioId)
        {
            System.DateTime fechaFin = System.DateTime.Parse("2222-02-02 22:22");
            var sesion = this.iDbContext.Set<Sesion>().Where(x => x.Usuario.UsuarioId == pUsuarioId && x.FechaFin == fechaFin).FirstOrDefault();
            if (sesion != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Sesion ObtenerSesionNoFinalizada(int pUsuarioId)
        {
            System.DateTime fechaFin = System.DateTime.Parse("2222-02-02 22:22");
            Sesion sesion = this.iDbContext.Set<Sesion>().Where(x => x.Usuario.UsuarioId == pUsuarioId && x.FechaFin == fechaFin).FirstOrDefault();
            sesion.Conjunto = this.iDbContext.Set<Conjunto>().Where(x => x.ConjuntoId == sesion.ConjuntoId).FirstOrDefault();
            sesion.Categoria = this.iDbContext.Set<Categoria>().Where(x => x.Id == sesion.CategoriaId).FirstOrDefault();
            sesion.Dificultad = this.iDbContext.Set<Dificultad>().Where(x => x.Id == sesion.DificultadId).FirstOrDefault();
            return sesion;
=======
        public IEnumerable<Sesion> ObtenerSesionActiva()
        {
            var sesionActiva = from s in iDbContext.Sesiones
                               where s.FechaFin.Equals(null)
                               select s;
            return sesionActiva;
>>>>>>> Stashed changes
        }
    }
}

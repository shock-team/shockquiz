﻿using ShockQuiz.Dominio;
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


        public IEnumerable<Sesion> ObtenerSesionActiva()
        {
            var sesionActiva = from s in iDbContext.Sesiones
                               where s.FechaFin.Equals(null)
                               select s;
            return sesionActiva;
        }
    }
}

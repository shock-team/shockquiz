using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Linq;
using ShockQuiz.Excepciones;
using System;

namespace ShockQuiz.Forms
{
    class FachadaLogin
    {
        /// <summary>
        /// Verifica si el nombre de usuario ingresado y su contraseña coinciden en la base de datos
        /// </summary>
        /// <param name="pUser">Nombre del usuario</param>
        /// <param name="pPass">Contraseña del usuario</param>
        /// <returns></returns>
        public int CheckLogin(string pUser, string pPass)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Usuario user = bUoW.RepositorioUsuario.ObtenerPorNombre(pUser);

                    if (user.ContraseñaCorrecta(pPass))
                    {
                        return user.UsuarioId;
                    }
                    else
                    {
                        throw new ContraseñaIncorrectaException();
                    }
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para obtener una sesión aún activa presente
        /// en la base de datos.
        /// </summary>
        /// <returns></returns>
        public Sesion ObtenerSesionNoFinalizada()
        {
            Sesion res = null;
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    IEnumerable<Sesion> sesionesActivas = bUoW.RepositorioSesion.ObtenerSesionActiva();
                    if (sesionesActivas.Count() > 0)
                    {
                        res = sesionesActivas.First();
                    }
                }
            }
            return res;
        }


        /// <summary>
        /// Registra a un usuario en la base de datos de la aplicación
        /// </summary>
        /// <param name="pUser">Nombre del usuario</param>
        /// <param name="pPass">Contraseña del usuario</param>
        public void AddUser(string pUser, string pPass)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bool admin = false;
                    if (bUoW.RepositorioUsuario.ObtenerTodos().Count() == 0)
                    {
                        admin = true;
                    }

                    Usuario user = new Usuario()
                    {
                        Nombre = pUser,
                        Contraseña = pPass,
                        Admin = admin,
                        Sesiones = new List<Sesion>()
                    };
                    bUoW.RepositorioUsuario.Agregar(user);
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Verifica si un usuario es administrador
        /// </summary>
        /// <param name="pUsuario">El usuario a verificar</param>
        /// <returns></returns>
        public bool EsAdmin(string pUsuario)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Usuario user = bUoW.RepositorioUsuario.ObtenerPorNombre(pUsuario);

                    if (user.Admin)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Este método se encarga de cancelar una sesión que se encuentre activa
        /// </summary>
        public void CancelarSesionActiva()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActiva = bUoW.RepositorioSesion.ObtenerSesionActiva().First();
                    sesionActiva.FechaFin = DateTime.Now;
                    foreach (Pregunta pregunta in bUoW.RepositorioPregunta.ObtenerPreguntasPorSesion(sesionActiva.SesionId))
                    {
                        sesionActiva.Responder(false);
                        pregunta.SesionActualId = 0;
                    }
                    sesionActiva.SesionFinalizada = true;
                    bUoW.GuardarCambios();
                }
            }
        }
    }
}

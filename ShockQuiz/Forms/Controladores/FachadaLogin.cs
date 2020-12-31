using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Linq;
using ShockQuiz.Excepciones;
using System;
using ShockQuiz.IO;

namespace ShockQuiz.Forms
{
    class FachadaLogin
    {
        /// <summary>
        /// Este método se utiliza para realizar un login a partir de un nombre de usuario y su contraseña,
        /// y devolver la información necesaria.
        /// </summary>
        /// <param name="pNombreDeUsuario">El nombre del usuario.</param>
        /// <param name="pClave">La contraseña del usuario.</param>
        /// <returns></returns>
        public LoginDTO Login(string pNombreDeUsuario, string pClave)
        {
            LoginDTO loginDTO = new LoginDTO();
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Usuario usuario = bUoW.RepositorioUsuario.ObtenerPorNombre(pNombreDeUsuario);
                    if (!usuario.ContraseñaCorrecta(pClave))
                    {
                        throw new ContraseñaIncorrectaException();
                    }
                    else
                    {
                        loginDTO.IdUsuario = usuario.UsuarioId;
                        loginDTO.EsAdmin = usuario.Admin;
                        Sesion sesionActual = bUoW.RepositorioSesion.ObtenerSesionActiva(usuario.UsuarioId);
                        if (sesionActual == null)
                        {
                            loginDTO.IdSesion = -1;
                        }
                        else
                        {
                            loginDTO.IdSesion = sesionActual.SesionId;
                        }
                    }
                }
            }
            return loginDTO;
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
        /// Este método se encarga de cancelar una sesión que se encuentre activa
        /// </summary>
        public void CancelarSesion(int pIdUsuario)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Sesion sesionActiva = bUoW.RepositorioSesion.ObtenerSesionActiva(pIdUsuario);
                    sesionActiva.FechaFin = DateTime.Now;
                    foreach (Pregunta pregunta in sesionActiva.Preguntas.ToList())
                    {
                        sesionActiva.Responder(false);
                    }
                    sesionActiva.SesionFinalizada = true;
                    bUoW.GuardarCambios();
                }
            }
        }
    }
}

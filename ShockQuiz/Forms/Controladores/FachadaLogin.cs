﻿using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Linq;

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
        public bool CheckLogin(string pUser, string pPass)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Usuario user = bUoW.RepositorioUsuario.Obtener(pUser);

                    if (user.ContraseñaCorrecta(pPass))
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
    }
}
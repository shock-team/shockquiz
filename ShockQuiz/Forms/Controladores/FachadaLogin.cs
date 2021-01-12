using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using ShockQuiz.Excepciones;
using ShockQuiz.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using ShockQuiz.Servicios;

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
            Usuario usuario = ServiciosUsuario.LoginUsuario(pNombreDeUsuario, pClave);
            loginDTO.IdUsuario = usuario.UsuarioId;
            loginDTO.EsAdmin = usuario.Admin;
            loginDTO.IdSesion = ServiciosSesion.ObtenerSesionActiva(usuario.UsuarioId);            
            return loginDTO;
        }

        /// <summary>
        /// Registra a un usuario en la base de datos de la aplicación
        /// </summary>
        /// <param name="pUser">Nombre del usuario</param>
        /// <param name="pPass">Contraseña del usuario</param>
        public void AddUser(string pUser, string pPass)
        {
            ServiciosUsuario.AgregarUsuario(pUser, pPass);
        }

        /// <summary>
        /// Este método se encarga de cancelar una sesión que se encuentre activa.
        /// </summary>
        /// <param name="pIdSesion">El ID de la sesión a cancelar.</param>
        public void CancelarSesion(int pIdSesion)
        {
            ServiciosSesion.CancelarSesion(pIdSesion);
        }
    }
}

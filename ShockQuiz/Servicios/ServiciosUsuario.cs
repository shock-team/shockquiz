using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.Dominio;
using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Excepciones;


namespace ShockQuiz.Servicios
{
    public class ServiciosUsuario
    {
        /// <summary>
        /// Este método se utiliza para realizar un login, devolviendo el usuario si el nombre
        /// y clave son correctos.
        /// </summary>
        /// <param name="pNombre">El nombre del usuario.</param>
        /// <param name="pClave">Su contraseña.</param>
        /// <returns></returns>
        public static Usuario LoginUsuario(string pNombre, string pClave)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Usuario usuario = bUoW.RepositorioUsuario.ObtenerPorNombre(pNombre);
                    if (usuario.ContraseñaCorrecta(pClave))
                    {
                        return usuario;
                    }
                    else
                    {
                        throw new ContraseñaIncorrectaException();
                    }
                }
            }
        }

        /// <summary>
        /// Registra a un usuario en la base de datos de la aplicación.
        /// </summary>
        /// <param name="pNombre">Nombre del usuario</param>
        /// <param name="pClave">Contraseña del usuario</param>
        public static void AgregarUsuario(string pNombre, string pClave)
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
                        Nombre = pNombre,
                        Contraseña = pClave,
                        Admin = admin,
                        Sesiones = new List<Sesion>()
                    };
                    bUoW.RepositorioUsuario.Agregar(user);
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Incrementa la autoridad de un usuario a administrador
        /// </summary>
        /// <param name="pUsuario">El usuario</param>
        /// <returns></returns>
        public static void UsuarioAAdmin(string pUsuario)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.RepositorioUsuario.Ascender(pUsuario);
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para obtener un usuario de la base de datos a partir de su ID.
        /// </summary>
        /// <param name="pIdUsuario">El ID del usuario a obtener.</param>
        /// <returns></returns>
        public static Usuario ObtenerUsuario(int pIdUsuario)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioUsuario.Obtener(pIdUsuario);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.DAL;
using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;

namespace ShockQuiz.Forms
{
    class FachadaLogin
    {
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

        public void AddUser(string pUser, string pPass)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Usuario user = new Usuario()
                    {
                        Nombre = pUser,
                        Contraseña = pPass,
                        Admin = false,
                        Sesiones = new List<Sesion>()
                    };
                    bUoW.RepositorioUsuario.Agregar(user);
                    bUoW.GuardarCambios();
                }
            }
        }
    }
}

using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Forms
{
    class FachadaMenu
    {
        /// <summary>
        /// Verifica si un usuario es administrados
        /// </summary>
        /// <param name="pUsuario">El usuario a verificar</param>
        /// <returns></returns>
        public bool EsAdmin(string pUsuario)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Usuario user = bUoW.RepositorioUsuario.Obtener(pUsuario);

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
    }
}

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

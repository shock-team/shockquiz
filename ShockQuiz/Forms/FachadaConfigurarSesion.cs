using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.DAL;
using ShockQuiz.Dominio;
using ShockQuiz.DAL.EntityFramework;

namespace ShockQuiz.Forms
{
    public class FachadaConfigurarSesion
    {
        public IEnumerable<string> ObtenerConjuntos()
        {
            List<string> conjuntos = new List<string>();
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (Conjunto conjunto in bUoW.RepositorioConjunto.ObtenerTodas())
                    {
                        conjuntos.Add(conjunto.Nombre);
                    }
                }
            }
            return conjuntos;
        }

        public IEnumerable<string> ObtenerCategorias(string pConjunto)
        {
            List<string> categorias = new List<string>();
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (Categoria categoria in bUoW.RepositorioPregunta.ObtenerCategorias(pConjunto))
                    {
                        categorias.Add(categoria.Nombre); 
                    }
                }
            }
            return categorias;
        }

        public IEnumerable<string> ObtenerDificultades()
        {
            List<string> dificultades = new List<string>();
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (Dificultad dificultad in bUoW.RepositorioDificultad.ObtenerTodas())
                    {
                        dificultades.Add(dificultad.Nombre);
                    }
                }
            }
            return dificultades;
        }
    }
}

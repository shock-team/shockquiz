using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioPregunta:Repositorio<Pregunta, ShockQuizDbContext>, IRepositorioPregunta
    {
        static Random rnd = new Random();
        public RepositorioPregunta(ShockQuizDbContext pDbContext) : base(pDbContext) { }
        

        public void AgregarPreguntas(IEnumerable<Pregunta> pPreguntas)
        {
            foreach (Pregunta item in pPreguntas)
            {
                iDbContext.Set<Pregunta>().Add(item);
            }
        }

        public IEnumerable<Pregunta> ObtenerTodas()
        {
            return this.iDbContext.Set<Pregunta>();
        }

        public IEnumerable<Pregunta> ObtenerPreguntas(Categoria pCategoria, Dificultad pDificultad, Conjunto pConjunto, int pCantidad = 10)
        {
            List<Pregunta> ans = new List<Pregunta>();
            ans = this.iDbContext.Set<Pregunta>().Where(x => x.Categoria == pCategoria && x.Dificultad == pDificultad && x.ConjuntoId==pConjunto.ConjuntoId).ToList();
            return ans.OrderBy(x => rnd.Next()).Take(pCantidad);
        }

        public string GetOrCreate(string pNombre, string pConjunto)
        {
            var manager = ((IObjectContextAdapter)iDbContext).ObjectContext;

            var dbPregunta = from t in iDbContext.Preguntas
                             where t.Nombre == pNombre
                             && t.Conjunto.Nombre == pConjunto
                             select t;


            if (dbPregunta.Count() > 0)
            {
                return string.Empty;
            }

            var cachedPregunta = manager.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
                                .Select(x => x.Entity)
                                .OfType<Pregunta>()
                                .SingleOrDefault(x => x.Nombre == pNombre);
            if (cachedPregunta != null)
            {
                return string.Empty;
            }

            return pNombre;
        }

        public IEnumerable<Categoria> ObtenerCategorias(int pConjuntoId)
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            foreach (var pregunta in iDbContext.Set<Pregunta>().Where(x => x.ConjuntoId == pConjuntoId))
            {
                if (!listaCategorias.Contains(pregunta.Categoria))
                {
                    listaCategorias.Add(pregunta.Categoria);
                }
            }
            return listaCategorias;
        }
    }
}

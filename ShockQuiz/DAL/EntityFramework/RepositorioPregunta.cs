using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ShockQuiz.Excepciones;

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

            var list = from t in iDbContext.Preguntas
                       .Include(x => x.Respuestas)
                       .Include(x => x.Categoria)
                       .Include(x => x.Dificultad)
                       .Include(x => x.Conjunto)
                       where t.Categoria.Nombre == pCategoria.Nombre
                       && t.Dificultad.Nombre == pDificultad.Nombre
                       && t.Conjunto.Nombre == pConjunto.Nombre
                       select t;
            if (list.Count() >= pCantidad)
            {
                return list.ToList().OrderBy(x => rnd.Next()).Take(pCantidad);
            }
            else
            {
                throw new PreguntasInsuficientesException();
            }
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

        public IEnumerable<Categoria> ObtenerCategorias(string pConjunto)
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            listaPreguntas = (from t in iDbContext.Preguntas.Include(x => x.Categoria).Include(x => x.Conjunto) where t.Conjunto.Nombre == pConjunto select t).ToList();
            foreach (Pregunta pregunta in listaPreguntas)
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

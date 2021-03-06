﻿using ShockQuiz.Dominio;
using ShockQuiz.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioPregunta : Repositorio<Pregunta, ShockQuizDbContext>, IRepositorioPregunta
    {
        static Random rnd = new Random();
        public RepositorioPregunta(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        /// <summary>
        /// Agrega una lista <paramref name="pPreguntas"/> a la base de datos.
        /// </summary>
        /// <param name="pPreguntas">IEnumerable de Preguntas</param>
        public void AgregarPreguntas(IEnumerable<Pregunta> pPreguntas)
        {
            foreach (Pregunta item in pPreguntas)
            {
                iDbContext.Set<Pregunta>().Add(item);
            }
        }

        /// <summary>
        /// Obtiene todas las Preguntas de la base de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pregunta> ObtenerTodas()
        {
            return this.iDbContext.Set<Pregunta>();
        }

        /// <summary>
        /// Obtiene una <paramref name="pCantidad"/> determinada (o no) de preguntas filtradas por 
        /// <paramref name="pCategoria"/>, <paramref name="pConjunto"/> y <paramref name="pDificultad"/>.
        /// </summary>
        /// <param name="pCategoria">Categría</param>
        /// <param name="pDificultad">Dificultad</param>
        /// <param name="pConjunto">Conjunto</param>
        /// <param name="pCantidad">Cantidad de Preguntas</param>
        /// <returns></returns>
        public IEnumerable<Pregunta> ObtenerPreguntas(int pCategoria, int pDificultad, int pConjunto, int pCantidad = 10)
        {

            var list = from t in iDbContext.Preguntas
                       .Include(x => x.Respuestas)
                       .Include(x => x.Categoria)
                       .Include(x => x.Dificultad)
                       .Include(x => x.Conjunto)
                       .Include(x => x.Sesiones)
                       where t.Categoria.Id == pCategoria
                       && t.Dificultad.Id == pDificultad
                       && t.Conjunto.ConjuntoId == pConjunto
                       select t;
            if (list.Count() >= pCantidad)
            {
                return list.Take(pCantidad);
            }
            else
            {
                throw new PreguntasInsuficientesException();
            }
        }

        public string GetOrCreate(string pNombre, string pConjunto)
        {
            var manager = ((IObjectContextAdapter)iDbContext).ObjectContext;

            var dbPregunta = iDbContext.Preguntas.Include(x => x.Conjunto).ToList()
                .Where(x => x.Nombre == pNombre && x.Conjunto.Nombre == pConjunto).Any();



            if (dbPregunta)
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

        /// <summary>
        /// Devuelve una lista de las Categorías de un <paramref name="pConjunto"/>.
        /// </summary>
        /// <param name="pConjunto"></param>
        /// <returns></returns>
        public IEnumerable<Categoria> ObtenerCategorias(int pConjunto)
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            listaPreguntas = (from t in iDbContext.Preguntas.Include(x => x.Categoria).Include(x => x.Conjunto) where t.Conjunto.ConjuntoId == pConjunto select t).ToList();
            foreach (Pregunta pregunta in listaPreguntas)
            {
                if (!listaCategorias.Contains(pregunta.Categoria))
                {
                    listaCategorias.Add(pregunta.Categoria);
                }
            }
            return listaCategorias;
        }

        /// <summary>
        /// Devuelve una lista de las Dificultades de un <paramref name="pConjunto"/>.
        /// </summary>
        /// <param name="pConjunto"></param>
        /// <returns></returns>
        public IEnumerable<Dificultad> ObtenerDificultades(int pConjunto)
        {
            List<Dificultad> listaDificultades = new List<Dificultad>();
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            listaPreguntas = (from t in iDbContext.Preguntas.Include(x => x.Dificultad).Include(x => x.Conjunto) where t.Conjunto.ConjuntoId == pConjunto select t).ToList();
            foreach (Pregunta pregunta in listaPreguntas)
            {
                if (!listaDificultades.Contains(pregunta.Dificultad))
                {
                    listaDificultades.Add(pregunta.Dificultad);
                }
            }
            return listaDificultades;
        }

        /// <summary>
        /// Este método se utiliza para obtener una pregunta y sus respuestas
        /// a partir de si ID.
        /// </summary>
        /// <param name="pIdPregunta">El ID de la pregunta a traer</param>
        /// <returns></returns>
        public Pregunta ObtenerPreguntaPorId(int pIdPregunta)
        {
            var pregunta = (from p in iDbContext.Preguntas.Include(x => x.Respuestas)
                               .Include("Conjunto")
                               .Include("Dificultad")
                               .Include("Categoria")
                               .Include("Sesiones")
                               .Include("Respuestas")
                            where p.PreguntaId == pIdPregunta
                            select p);
            return pregunta.First();
        }

        /// <summary>
        /// Este método se utiliza para obtener la respuesta correcta a una pregunta en particular
        /// </summary>
        /// <param name="pIdPregunta">El ID de la pregunta a responder.</param>
        /// <returns></returns>
        public Respuesta ObtenerRespuestaCorrecta(int pIdPregunta)
        {
            var respuestaCorrecta = (from r in iDbContext.Respuestas
                                     where r.PreguntaId == pIdPregunta &&
                                     r.EsCorrecta
                                     select r);
            return respuestaCorrecta.First();
        }
    }
}

﻿using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
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

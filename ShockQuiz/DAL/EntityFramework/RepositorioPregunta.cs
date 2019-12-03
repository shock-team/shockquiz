﻿using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    class RepositorioPregunta:Repositorio<Pregunta, ShockQuizDbContext>, IRepositorioPregunta
    {
        static Random rnd = new Random();
        public RepositorioPregunta(ShockQuizDbContext pDbContext) : base(pDbContext) { }
        

        public void AgregarConjunto(IEnumerable<Pregunta> pConjunto)
        {
            foreach (Pregunta item in pConjunto)
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
    }
}

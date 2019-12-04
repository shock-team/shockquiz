﻿using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework
{
    public class RepositorioCategoria:Repositorio<Categoria, ShockQuizDbContext>
    {
        public RepositorioCategoria(ShockQuizDbContext pDbContext) : base(pDbContext) { }

        public IEnumerable<Categoria> ObtenerTodas()
        {
            return this.iDbContext.Set<Categoria>();
        }
    }
}

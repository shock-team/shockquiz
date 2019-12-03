﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.DAL;

namespace ShockQuiz.DAL.EntityFramework
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ShockQuizDbContext iDbContext;
        private bool iDisposedValue = false;

        public IRepositorioPregunta RepositorioPreguntas { get; private set; }
        public IRepositorioPregunta RepositorioPregunta { get; private set; }
        public IRepositorioUsuario RepositorioUsuario { get; private set; }
        public IRepositorioSesion RepositorioSesion { get; private set; }

        public IRepositorioUsuario RepositorioUsuarios { get; private set; }

        public IRepositorioSesion RepositorioSesion { get; private set; }

        public UnitOfWork(ShockQuizDbContext pDbContext)
        {
            if (pDbContext == null)
            {
                throw new ArgumentNullException(nameof(pDbContext));
            }

            this.iDbContext = pDbContext;
            this.RepositorioPregunta = new RepositorioPregunta(pDbContext);
            this.RepositorioSesion = new RepositorioSesion(pDbContext);
            this.RepositorioUsuario = new RepositorioUsuario(pDbContext);
        }

        public void GuardarCambios()
        {
            this.iDbContext.SaveChanges();
        }

        protected virtual void Dispose(bool pDisposing)
        {
            if (!this.iDisposedValue)
            {
                if (pDisposing)
                {
                    this.iDbContext.Dispose();
                }

                this.iDisposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}

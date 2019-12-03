﻿using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework.Mapping
{
    class SesionMap : EntityTypeConfiguration<Sesion>
    {
        public SesionMap()
        {
            this.HasKey(x => x.SesionId);
            this.Property(x => x.SesionId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("id");

            this.Property(x => x.CantidadPreguntas)
                .HasColumnName("cantidadPreguntas")
                .IsRequired();

            this.HasRequired<Categoria>(x => x.Categoria)
                .WithMany(x => x.Sesiones)
                .HasForeignKey<int>(x => x.CategoriaId);

            this.HasRequired<Dificultad>(x => x.Dificultad)
                .WithMany(x => x.Sesiones)
                .HasForeignKey<int>(x => x.DificultadId);

            this.Property(x => x.Puntaje)
                .HasColumnName("puntaje")
                .IsRequired();

            this.



            


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShockQuiz.Dominio;

namespace ShockQuiz.DAL.EntityFramework.Mapping
{
    class PreguntaMap:EntityTypeConfiguration<Pregunta>
    {
        public PreguntaMap()
        {
            this.ToTable("Preguntas");

            this.HasKey(x => x.PreguntaId);
            this.Property(x => x.PreguntaId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("id");

            this.Property(x => x.Nombre)
                .IsRequired()
                .HasColumnName("nombre");

            this.HasRequired<Categoria>(x => x.Categoria)
                .WithMany(x => x.Preguntas)
                .HasForeignKey<int>(x => x.CategoriaId);

            this.HasRequired<Dificultad>(x => x.Dificultad)
                .WithMany(x => x.Preguntas)
                .HasForeignKey<int>(x => x.DificultadId);

            this.HasRequired<Conjunto>(x => x.Conjunto)
                .WithMany(x => x.Preguntas)
                .HasForeignKey<int>(x => x.ConjuntoId);

            this.HasRequired(x => x.RespuestaCorrecta)
                .WithRequiredPrincipal(x => x.PreguntaCorrecta);
        }
    }
}

using ShockQuiz.Dominio;
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

            


        }
    }
}

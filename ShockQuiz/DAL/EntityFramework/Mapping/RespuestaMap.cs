using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL.EntityFramework.Mapping
{
    class RespuestaMap:EntityTypeConfiguration<Respuesta>
    {
        public RespuestaMap()
        {
            this.ToTable("Respuestas");

            this.HasKey(x => x.RespuestaId);
            this.Property(x => x.RespuestaId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("id");

            this.Property(x => x.DefRespuesta)
                .HasColumnName("respuesta")
                .IsRequired();

            this.HasOptional(x => x.Pregunta)
                .WithMany(x => x.RespuestasIncorrectas)
                .HasForeignKey(x => x.PreguntaId);
        }
    }
}

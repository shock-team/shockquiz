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
            this.HasKey(x => x.RespuestaId);
            this.Property(x => x.RespuestaId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("id");

            this.Property(x => x.DefRespuesta)
                .HasColumnName("respuesta")
                .HasMaxLength(100)
                .IsRequired();

            this.HasRequired<Pregunta>(x => x.Pregunta)
                .WithMany(x => x.RespuestasIncorrectas)
                .HasForeignKey<int>(x => x.PreguntaId);
        }
    }
}

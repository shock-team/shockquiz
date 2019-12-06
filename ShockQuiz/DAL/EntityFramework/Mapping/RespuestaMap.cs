using ShockQuiz.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace ShockQuiz.DAL.EntityFramework.Mapping
{
    class RespuestaMap : EntityTypeConfiguration<Respuesta>
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

            this.HasRequired(x => x.Pregunta)
                .WithMany(x => x.Respuestas)
                .HasForeignKey(x => x.PreguntaId);
        }
    }
}

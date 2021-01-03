using ShockQuiz.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace ShockQuiz.DAL.EntityFramework.Mapping
{
    class SesionMap : EntityTypeConfiguration<Sesion>
    {
        public SesionMap()
        {
            this.ToTable("Sesiones");

            this.HasKey(x => x.SesionId);
            this.Property(x => x.SesionId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("id");

            this.Property(x => x.Puntaje)
                .HasColumnName("puntaje")
                .IsRequired();

            this.Property(x => x.FechaFin)
                .HasColumnName("fechaInicio");

            this.Property(x => x.FechaFin)
                .HasColumnName("fechaFin")
                .IsRequired();

            this.HasRequired<Usuario>(x => x.Usuario)
                .WithMany(x => x.Sesiones)
                .HasForeignKey<int>(x => x.UsuarioId);

            this.HasMany<Pregunta>(x => x.Preguntas)
                .WithMany(x => x.Sesiones)
                .Map(cs =>
                            {
                                cs.MapLeftKey("SesionRefId");
                                cs.MapRightKey("PreguntaRefId");
                                cs.ToTable("SesionPregunta");
                            });

            this.Property(x => x.RespuestasCorrectas);
            this.Property(x => x.CantidadTotalPreguntas);
        }
    }
}

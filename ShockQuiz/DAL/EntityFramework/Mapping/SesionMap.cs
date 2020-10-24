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

            this.Property(x => x.FechaFin)
                .HasColumnName("fechaInicio")
                .IsRequired();

            this.Property(x => x.FechaFin)
                .HasColumnName("fechaFin")
                .IsRequired();

            this.HasRequired<Usuario>(x => x.Usuario)
                .WithMany(x => x.Sesiones)
                .HasForeignKey<int>(x => x.UsuarioId);

            this.HasRequired<Conjunto>(x => x.Conjunto)
                .WithMany(x => x.Sesiones)
                .HasForeignKey<int>(x => x.ConjuntoId);

            this.HasMany<Pregunta>(x => x.Preguntas);

            this.Property(x => x.RespuestasCorrectas);
        }
    }
}

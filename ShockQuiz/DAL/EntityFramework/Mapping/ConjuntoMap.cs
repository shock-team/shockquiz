using ShockQuiz.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace ShockQuiz.DAL.EntityFramework.Mapping
{
    class ConjuntoMap : EntityTypeConfiguration<Conjunto>
    {
        public ConjuntoMap()
        {
            this.ToTable("Conjuntos");

            this.HasKey(x => x.ConjuntoId);
            this.Property(x => x.ConjuntoId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("id");

            this.Property(x => x.Nombre)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nombre");

            this.Property(x => x.TiempoEsperadoPorPregunta)
                .IsRequired();

            this.Property(x => x.Token)
                .IsOptional()
                .HasColumnName("tokenAPI");

        }
    }
}

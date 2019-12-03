using ShockQuiz.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace ShockQuiz.DAL.EntityFramework.Mapping
{
    class DificultadMap : EntityTypeConfiguration<Dificultad>
    {
        public DificultadMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("id");

            this.Property(x => x.Nombre)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nombre");
        }
    }
}

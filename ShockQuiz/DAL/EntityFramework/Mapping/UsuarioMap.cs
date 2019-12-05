using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShockQuiz.Dominio;

namespace ShockQuiz.DAL.EntityFramework.Mapping
{
    class UsuarioMap:EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this.ToTable("Usuarios");

            this.HasKey(pUsuario => pUsuario.UsuarioId);
            this.Property(pUsuario => pUsuario.UsuarioId)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.HasIndex(pUsuario => pUsuario.Nombre)
                .IsUnique();
            this.Property(pUsuario => pUsuario.Nombre)
                .HasColumnName("user")
                .IsRequired()
                .HasMaxLength(20);

            this.Property(pUsuario => pUsuario.Contraseña)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}

using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TocaLivros.Domain.Models;

namespace TocaLivros.Infraestructure.EntityFramework.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            Property(x => x.UsuarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.UserName).HasMaxLength(50).
                HasColumnAnnotation("Index", new IndexAnnotation
                (new IndexAttribute("IX_Username") { IsUnique = true })).IsRequired();
        }
    }
}

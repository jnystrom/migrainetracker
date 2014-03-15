using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Gazallion.MigraineManager.Data.Models;

namespace Gazallion.MigraineManager.Data.SqlServer.Models.Mapping
{
    public class MedTypeMap : EntityTypeConfiguration<MedType>
    {
        public MedTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.MedTypeId);

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MedType");
            this.Property(t => t.MedTypeId).HasColumnName("MedTypeId");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}

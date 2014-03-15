using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Gazallion.MigraineManager.Data.Models;

namespace Gazallion.MigraineManager.Data.SqlServer.Models.Mapping
{
    public class MedicineMap : EntityTypeConfiguration<Medicine>
    {
        public MedicineMap()
        {
            // Primary Key
            this.HasKey(t => t.MedId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Medicine");
            this.Property(t => t.MedId).HasColumnName("MedId");
            this.Property(t => t.MedTypeId).HasColumnName("MedTypeId");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.MedType)
                .WithMany(t => t.Medicines)
                .HasForeignKey(d => d.MedTypeId);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Gazallion.MigraineManager.Data.Models;

namespace Gazallion.MigraineManager.Data.SqlServer.Models.Mapping
{
    public class ConditionMap : EntityTypeConfiguration<Condition>
    {
        public ConditionMap()
        {
            // Primary Key
            this.HasKey(t => t.ConditionId);

            // Properties
            this.Property(t => t.ConditionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Condition");
            this.Property(t => t.ConditionId).HasColumnName("ConditionId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}

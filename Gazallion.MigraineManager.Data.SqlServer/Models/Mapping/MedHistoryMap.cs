using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Gazallion.MigraineManager.Data.Models;

namespace Gazallion.MigraineManager.Data.SqlServer.Models.Mapping
{
    public class MedHistoryMap : EntityTypeConfiguration<MedHistory>
    {
        public MedHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.MedHistoryId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MedHistory");
            this.Property(t => t.MedHistoryId).HasColumnName("MedHistoryId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.ConditionId).HasColumnName("ConditionId");
            this.Property(t => t.MedId).HasColumnName("MedId");

            // Relationships
            this.HasRequired(t => t.Condition)
                .WithMany(t => t.MedHistories)
                .HasForeignKey(d => d.ConditionId);
            this.HasOptional(t => t.Medicine)
                .WithMany(t => t.MedHistories)
                .HasForeignKey(d => d.MedId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.MedHistories)
                .HasForeignKey(d => d.UserId);

        }
    }
}

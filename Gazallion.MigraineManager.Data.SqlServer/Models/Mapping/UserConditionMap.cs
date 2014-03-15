using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Gazallion.MigraineManager.Data.Models;

namespace Gazallion.MigraineManager.Data.SqlServer.Models.Mapping
{
    public class UserConditionMap : EntityTypeConfiguration<UserCondition>
    {
        public UserConditionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.ConditionId });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ConditionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("UserCondition");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ConditionId).HasColumnName("ConditionId");
            this.Property(t => t.IncidentThreshold).HasColumnName("IncidentThreshold");
            this.Property(t => t.ThresholdTimePeriod).HasColumnName("ThresholdTimePeriod");

            // Relationships
            this.HasRequired(t => t.Condition)
                .WithMany(t => t.UserConditions)
                .HasForeignKey(d => d.ConditionId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserConditions)
                .HasForeignKey(d => d.UserId);

        }
    }
}

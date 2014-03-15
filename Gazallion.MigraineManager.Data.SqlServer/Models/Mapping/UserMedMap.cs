using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Gazallion.MigraineManager.Data.Models;

namespace Gazallion.MigraineManager.Data.SqlServer.Models.Mapping
{
    public class UserMedMap : EntityTypeConfiguration<UserMed>
    {
        public UserMedMap()
        {
            // Primary Key
            this.HasKey(t => t.UserMedId);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserMed");
            this.Property(t => t.UserMedId).HasColumnName("UserMedId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.MedId).HasColumnName("MedId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");

            // Relationships
            this.HasRequired(t => t.Medicine)
                .WithMany(t => t.UserMeds)
                .HasForeignKey(d => d.MedId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserMeds)
                .HasForeignKey(d => d.UserId);

        }
    }
}

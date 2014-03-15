using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Gazallion.MigraineManager.Data.Models;

namespace Gazallion.MigraineManager.Data.SqlServer.Models.Mapping
{
    public class DietMap : EntityTypeConfiguration<Diet>
    {
        public DietMap()
        {
            // Primary Key
            this.HasKey(t => t.DietId);

            // Properties
            this.Property(t => t.FoodItemName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Diet");
            this.Property(t => t.DietId).HasColumnName("DietId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.MedHistoryId).HasColumnName("MedHistoryId");
            this.Property(t => t.FoodItemName).HasColumnName("FoodItemName");

            // Relationships
            this.HasRequired(t => t.MedHistory)
                .WithMany(t => t.Diets)
                .HasForeignKey(d => d.MedHistoryId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Diets)
                .HasForeignKey(d => d.UserId);

        }
    }
}

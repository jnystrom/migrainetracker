using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Gazallion.MigraineManager.Data.Models;

namespace Gazallion.MigraineManager.Data.SqlServer.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.AddressId);

            // Properties
            this.Property(t => t.StreetName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.StreetNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Region)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ZipCode)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.StreetName).HasColumnName("StreetName");
            this.Property(t => t.StreetNumber).HasColumnName("StreetNumber");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Region).HasColumnName("Region");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(s => s.Addresses )
                .HasForeignKey(d => d.UserId);

        }
    }
}

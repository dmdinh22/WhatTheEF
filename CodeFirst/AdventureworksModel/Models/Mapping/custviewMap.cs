using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace AdventureworksModel.Models.Mapping
{
    public class custviewMap : EntityTypeConfiguration<custview>
    {
        public custviewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CustomerID, t.FirstName, t.LastName });

            // Properties
            this.Property(t => t.CustomerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CompanyName)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("custview");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
        }
    }
}

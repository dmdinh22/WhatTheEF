using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace AdventureworksModel.Models.Mapping
{
    public class BuildVersionMap : EntityTypeConfiguration<BuildVersion>
    {
        public BuildVersionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SystemInformationID, t.Database_Version, t.VersionDate, t.ModifiedDate });

            // Properties
            this.Property(t => t.Database_Version)
                .IsRequired()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("BuildVersion");
            this.Property(t => t.SystemInformationID).HasColumnName("SystemInformationID");
            this.Property(t => t.Database_Version).HasColumnName("Database Version");
            this.Property(t => t.VersionDate).HasColumnName("VersionDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}

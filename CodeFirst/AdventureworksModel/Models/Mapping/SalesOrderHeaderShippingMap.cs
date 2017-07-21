using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace AdventureworksModel.Models.Mapping
{
    public class SalesOrderHeaderShippingMap : EntityTypeConfiguration<SalesOrderHeaderShipping>
    {
        public SalesOrderHeaderShippingMap()
        {
            // Primary Key
            this.HasKey(t => t.SalesOrderID);

            // Properties
            this.Property(t => t.SalesOrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ShipMethod)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SalesOrderHeaderShipping", "SalesLT");
            this.Property(t => t.SalesOrderID).HasColumnName("SalesOrderID");
            this.Property(t => t.ShipDate).HasColumnName("ShipDate");
            this.Property(t => t.ShipToAddressID).HasColumnName("ShipToAddressID");
            this.Property(t => t.ShipMethod).HasColumnName("ShipMethod");

            // Relationships
            this.HasRequired(t => t.SalesOrderHeader)
                .WithOptional(t => t.SalesOrderHeaderShipping);

        }
    }
}

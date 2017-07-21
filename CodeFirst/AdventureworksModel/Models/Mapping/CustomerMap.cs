using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace AdventureworksModel.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(8);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MiddleName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Suffix)
                .HasMaxLength(10);

            this.Property(t => t.CompanyName)
                .HasMaxLength(128);

            this.Property(t => t.SalesPerson)
                .HasMaxLength(256);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(25);

            this.Property(t => t.TimeStamp)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Customer", "SalesLT");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Suffix).HasColumnName("Suffix");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.SalesPerson).HasColumnName("SalesPerson");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
        }
    }
}

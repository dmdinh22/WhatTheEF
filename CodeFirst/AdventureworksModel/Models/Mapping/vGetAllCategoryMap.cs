using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace AdventureworksModel.Models.Mapping
{
    public class vGetAllCategoryMap : EntityTypeConfiguration<vGetAllCategory>
    {
        public vGetAllCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ParentProductCategoryName);

            // Properties
            this.Property(t => t.ParentProductCategoryName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ProductCategoryName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vGetAllCategories", "SalesLT");
            this.Property(t => t.ParentProductCategoryName).HasColumnName("ParentProductCategoryName");
            this.Property(t => t.ProductCategoryName).HasColumnName("ProductCategoryName");
            this.Property(t => t.ProductCategoryID).HasColumnName("ProductCategoryID");
        }
    }
}

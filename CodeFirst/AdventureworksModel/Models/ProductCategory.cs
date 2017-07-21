using System;
using System.Collections.Generic;

namespace AdventureworksModel.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new List<Product>();
            this.ProductCategory1 = new List<ProductCategory>();
        }

        public int ProductCategoryID { get; set; }
        public Nullable<int> ParentProductCategoryID { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory1 { get; set; }
        public virtual ProductCategory ProductCategory2 { get; set; }
    }
}

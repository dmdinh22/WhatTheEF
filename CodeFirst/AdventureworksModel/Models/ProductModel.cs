using System;
using System.Collections.Generic;

namespace AdventureworksModel.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            this.Products = new List<Product>();
            this.ProductModelProductDescriptions = new List<ProductModelProductDescription>();
        }

        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AdventureworksModel.Models
{
    public class CustomerAddress
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

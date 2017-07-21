using System;
using System.Collections.Generic;

namespace AdventureworksModel.Models
{
    public class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            this.SalesOrderDetails = new List<SalesOrderDetail>();
        }

        public int SalesOrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public Nullable<int> BillToAddressID { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public decimal SubTotal { get; set; }
        public string Comment { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual SalesOrderHeaderShipping SalesOrderHeaderShipping { get; set; }
    }
}

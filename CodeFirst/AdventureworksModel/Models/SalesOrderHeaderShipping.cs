using System;
using System.Collections.Generic;

namespace AdventureworksModel.Models
{
    public class SalesOrderHeaderShipping
    {
        public int SalesOrderID { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public Nullable<int> ShipToAddressID { get; set; }
        public string ShipMethod { get; set; }
        public virtual SalesOrderHeader SalesOrderHeader { get; set; }
    }
}

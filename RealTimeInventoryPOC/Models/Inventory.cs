using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RealTimeInventoryPOC.Models
{
    public class Inventory
    {
        public Inventory()
        {
        }
        public int Sku { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }
        
    }
}
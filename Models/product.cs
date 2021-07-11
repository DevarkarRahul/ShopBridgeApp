using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public partial class Product
    {
        public Product()
        {
            created = DateTime.Now;
        }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<System.DateTime> created { get; set; }
    }
}
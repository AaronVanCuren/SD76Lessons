using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _14_GeneralStore.Models
{
    public class UPCListItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string UPC { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
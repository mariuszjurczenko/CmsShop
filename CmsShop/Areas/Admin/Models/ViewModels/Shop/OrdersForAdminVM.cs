using System;
using System.Collections.Generic;

namespace CmsShop.Areas.Admin.Models.ViewModels.Shop
{
    public class OrdersForAdminVM
    {
        public int OrderNumber { get; set; }
        public string Username { get; set; }
        public decimal Total { get; set; }
        public Dictionary<string, int> ProductsAndQty { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
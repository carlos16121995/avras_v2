﻿namespace avras_v2.Domain.Entities.Products
{
    public class ProductBuy : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public decimal PurchaseValue { get; set; }
        public int Amount { get; set; }
        public DateTime BoughtIn { get; set; }

        public virtual Product? Product { get; set; }
    }
}

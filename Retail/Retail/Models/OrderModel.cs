using System;

namespace Retail.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public Double OrderAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class OrderItems
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }   
}
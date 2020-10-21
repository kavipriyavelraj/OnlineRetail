using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retail.Models
{
    public class OrderModel
    {
        public int OrderId;
        public Double OrderAmount;
        public string OrderStatus;
        public DateTime OrderDate;
        public DateTime UpdatedDate;                
    }

    public class OrderItems
    {
        public int ItemId;
        public int OrderId;
        public int ProductId;
        public int Quantity;        
    }   
}
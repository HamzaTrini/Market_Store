using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class OrderFp
    {
        public OrderFp()
        {
            OrderProductFps = new HashSet<OrderProductFp>();
        }

        public decimal OrderId { get; set; }
        public string StoreName { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? UserId { get; set; }
        public decimal? Cost { get; set; }
        public string ImagePath { get; set; }
        public string Cart { get; set; }

        public virtual UserFp User { get; set; }
        public virtual ICollection<OrderProductFp> OrderProductFps { get; set; }
    }
}

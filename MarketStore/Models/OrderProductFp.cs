using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class OrderProductFp
    {
        public decimal OrderProductId { get; set; }
        public decimal? OrderId { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? Cart { get; set; }
        public DateTime? DateOrder { get; set; }

        public virtual OrderFp Order { get; set; }
        public virtual ProductFp Product { get; set; }
    }
}

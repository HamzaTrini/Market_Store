using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class StoreProductFp
    {
        public decimal StoreProductId { get; set; }
        public decimal? StoreId { get; set; }
        public decimal? ProductId { get; set; }

        public virtual ProductFp Product { get; set; }
        public virtual StoreFp Store { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarketStore.Models
{
    public partial class ProductFp
    {
        public ProductFp()
        {
            OrderProductFps = new HashSet<OrderProductFp>();
            StoreProductFps = new HashSet<StoreProductFp>();
        }

        public decimal ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ImagePath { get; set; }
        public decimal? Quantity { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }
        
        public virtual ICollection<OrderProductFp> OrderProductFps { get; set; }
        public virtual ICollection<StoreProductFp> StoreProductFps { get; set; }
    }
}

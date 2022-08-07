using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarketStore.Models
{
    public partial class StoreFp
    {
        public StoreFp()
        {
            StoreProductFps = new HashSet<StoreProductFp>();
        }

        public decimal StoreId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal? CategoryId { get; set; }
        public decimal? Totalsale { get; set; }
        public string Obtainsfinancial { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }



        public virtual CategoryFp Category { get; set; }
        public virtual ICollection<StoreProductFp> StoreProductFps { get; set; }
    }
}

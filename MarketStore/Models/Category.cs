using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public decimal CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageBath { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

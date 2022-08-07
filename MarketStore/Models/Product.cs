using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarketStore.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductCustomers = new HashSet<ProductCustomer>();
        }

        public decimal ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Sale { get; set; }
        public decimal? Price { get; set; }
        public decimal? CategoryId { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductCustomer> ProductCustomers { get; set; }
    }
}

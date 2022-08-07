using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarketStore.Models
{
    public partial class CategoryFp
    {
        public CategoryFp()
        {
            StoreFps = new HashSet<StoreFp>();
        }

        public decimal CatecoryId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }
        public virtual ICollection<StoreFp> StoreFps { get; set; }
    }
}

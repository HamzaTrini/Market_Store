using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarketStore.Models
{
    public partial class TestimonialFp
    {
        public decimal TestimonialId { get; set; }
        public decimal? UserId { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }
        
        public virtual UserFp User { get; set; }
    }
}

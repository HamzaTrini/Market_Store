using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarketStore.Models
{
    public partial class HomeFp
    {
        public decimal HomeId { get; set; }
        public string Discription { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile imageFile { set; get; }
    }
}

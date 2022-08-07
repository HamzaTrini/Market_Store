using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarketStore.Models
{
    public partial class UserFp
    {
        public UserFp()
        {
            LoginFps = new HashSet<LoginFp>();
            OrderFps = new HashSet<OrderFp>();
            TestimonialFps = new HashSet<TestimonialFp>();
        }

        public decimal? UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }

        public decimal? Password { get; set; }
        public string Username { get; set; }

       
        public decimal? Phonenumber { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }

        public virtual ICollection<LoginFp> LoginFps { get; set; }
        public virtual ICollection<OrderFp> OrderFps { get; set; }
        public virtual ICollection<TestimonialFp> TestimonialFps { get; set; }
    }
}

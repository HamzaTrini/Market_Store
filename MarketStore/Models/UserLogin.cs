using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class UserLogin
    {
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? CustomerId { get; set; }

      
        public virtual Role Role { get; set; }
    }
}

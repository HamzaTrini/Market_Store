using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class LoginFp
    {
        public decimal LoginId { get; set; }
        public string Name { get; set; }
        public decimal? Password { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? UserId { get; set; }

        public virtual RoleFp Role { get; set; }
        public virtual UserFp User { get; set; }
    }
}

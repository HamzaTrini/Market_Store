using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class RoleFp
    {
        public RoleFp()
        {
            LoginFps = new HashSet<LoginFp>();
        }

        public decimal RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<LoginFp> LoginFps { get; set; }
    }
}

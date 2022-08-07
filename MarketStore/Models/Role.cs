using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class Role
    {
        public Role()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public decimal RolesId { get; set; }
        public string RolesName { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}

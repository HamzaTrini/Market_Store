using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class CardFp
    {
        public decimal CardId { get; set; }
        public decimal? Password { get; set; }
        public decimal? Palance { get; set; }
        public decimal? Cvv { get; set; }
        public decimal? Cardnumber { get; set; }
    }
}

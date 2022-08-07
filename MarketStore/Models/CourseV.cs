using System;
using System.Collections.Generic;

#nullable disable

namespace MarketStore.Models
{
    public partial class CourseV
    {
        public decimal Courseid { get; set; }
        public string Coursename { get; set; }
        public DateTime? Dateto { get; set; }
        public DateTime? Datefrom { get; set; }
        public decimal? Status { get; set; }
        public decimal? Mark { get; set; }
    }
}

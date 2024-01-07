using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Testimonial
    {
        public decimal Tid { get; set; }
        public decimal? Isaccepted { get; set; }
        public string? Message { get; set; }
        public decimal? Userid { get; set; }

        public virtual User? User { get; set; }
    }
}

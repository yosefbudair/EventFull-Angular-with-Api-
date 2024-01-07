using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Review
    {
        public decimal Reviewid { get; set; }
        public decimal? Reviewvalue { get; set; }
        public decimal? Userid { get; set; }

        public virtual User? User { get; set; }
    }
}

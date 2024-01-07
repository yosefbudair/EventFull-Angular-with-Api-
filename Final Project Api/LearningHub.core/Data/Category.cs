using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Category
    {
        public Category()
        {
            Events = new HashSet<Event>();
        }

        public decimal Categoryid { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class ImageEvent
    {
        public decimal Imageeventid { get; set; }
        public string? Image { get; set; }
        public decimal? Eventid { get; set; }

        public virtual Event? Event { get; set; }
    }
}

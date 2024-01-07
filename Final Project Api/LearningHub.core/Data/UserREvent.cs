using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class UserREvent
    {
        public decimal Usereventid { get; set; }
        public decimal? Eventid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? User { get; set; }
    }
}

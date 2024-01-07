using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Event
    {
        public Event()
        {
            ImageEvents = new HashSet<ImageEvent>();
            UserREvents = new HashSet<UserREvent>();
        }

        public decimal Eventid { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public decimal? Limitattend { get; set; }
        public decimal? Isaccepted { get; set; }
        public decimal? Ispayed { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public decimal? Categoryid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<ImageEvent> ImageEvents { get; set; }
        public virtual ICollection<UserREvent> UserREvents { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
            Reviews = new HashSet<Review>();
            Testimonials = new HashSet<Testimonial>();
            UserREvents = new HashSet<UserREvent>();
        }

        public decimal Userid { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public string? Gender { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<UserREvent> UserREvents { get; set; }
    }
}

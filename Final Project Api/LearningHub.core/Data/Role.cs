using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public decimal Roleid { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

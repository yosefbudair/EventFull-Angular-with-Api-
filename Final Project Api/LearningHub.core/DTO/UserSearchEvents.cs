using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class UserSearchEvents
    {
        public string? Name { get; set; }
        public decimal? categoryid { get; set; }
      
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}

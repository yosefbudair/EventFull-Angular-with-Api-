using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Data
{
    public class Send
    {

        public string? recipientEmail { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public double? price { get; set; }
        public string? createdby { get; set; }
        public string? eventname { get; set; }
    }
}

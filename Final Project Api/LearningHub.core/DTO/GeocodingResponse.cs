using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    

        public class GeocodingResponse
        {
            public string display_name { get; set; }
            
           public Address address { get; set; }
        }

        public class Address
        {
            public string? country { get; set; }  
            public string? city { get; set; }
            public string? village { get; set; }
        }

       
    }


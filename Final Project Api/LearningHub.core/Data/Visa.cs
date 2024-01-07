using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Visa
    {
        public decimal Visaid { get; set; }
        public string Cardnumber { get; set; } = null!;
        public string? Owneremail { get; set; }
        public string? Cvv { get; set; }    
        public double? Balance { get; set; }
        public DateTime? Visadate { get; set; }
        public string? Cardname { get; set; }
    }
}

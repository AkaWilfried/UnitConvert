using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnitconverterData
{
    public class Conversionrates
    {
        
        public int Id { get; set; }
        [Required]
        public string Unit { get; set; }
        public double MetriqueEquivalent { get; set; }
        public string Equivalentunit { get; set; }
        public double Metricfactor { get; set; }
    }
}

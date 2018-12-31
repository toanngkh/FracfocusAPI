using System;
using System.Collections.Generic;

namespace FracfocusAPI.Models
{
    public partial class Fracfocus
    {
        public Guid PKey { get; set; }
        public DateTime? JobStartDate { get; set; }
        public DateTime? JobEndDate { get; set; }
        public string Apinumber { get; set; }
        public string StateNumber { get; set; }
        public string CountyNumber { get; set; }
        public string OperatorName { get; set; }
        public string WellName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Projection { get; set; }
        public double? Tvd { get; set; }
        public double? TotalBaseWaterVolume { get; set; }
        public double? TotalBaseNonWaterVolume { get; set; }
        public string StateName { get; set; }
        public string CountyName { get; set; }
        public bool? FederalWell { get; set; }
        public bool IndianWell { get; set; }
        public string TradeName { get; set; }
        public string Supplier { get; set; }
        public string Purpose { get; set; }
        public bool? IsWater { get; set; }
        public string IngredientName { get; set; }
        public string Casnumber { get; set; }
        public double? PercentHighAdditive { get; set; }
        public double? PercentHfjob { get; set; }
        public string IngredientComment { get; set; }
        public bool IngredientMsds { get; set; }
        public double? MassIngredient { get; set; }
    }
}

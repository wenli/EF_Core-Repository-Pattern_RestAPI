using System;

namespace BrandApplication.Business.DTOs // Corrected namespace
{
    public class BtStrategyDto // Corrected class name
    {
        public int Id { get; set; } // Added Id property
        public string? Strategy { get; set; }
        public string? Contract { get; set; }
        public string? Symbol { get; set; }
        public string? RsTimeframe { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? RsDate { get; set; }
        public string? DfTimeframe { get; set; }
        public long? TranTotal { get; set; }
        public long? TpCount { get; set; }
        public double? TpAmount { get; set; }
        public long? SlCount { get; set; }
        public double? SlAmount { get; set; }
        public double? Balance { get; set; }
        public double? WinRate { get; set; }
    }
}

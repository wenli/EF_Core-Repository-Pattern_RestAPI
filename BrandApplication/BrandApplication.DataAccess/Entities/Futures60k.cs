using System;
using System.Collections.Generic;

namespace BrandApplication.DataAccess.Entities;

public partial class Futures60k
{
    public string? Code { get; set; }

    public byte[]? Ts { get; set; }

    public double? Open { get; set; }

    public double? High { get; set; }

    public double? Low { get; set; }

    public double? Close { get; set; }

    public long? Volume { get; set; }

    public string? Bartypes { get; set; }

    public string? Pivot { get; set; }

    public string? Pivottypes { get; set; }

    public double? BullPivotLow { get; set; }

    public double? BearPivotHigh { get; set; }

    public double? TickStartPrice { get; set; }

    public double? TickPoint { get; set; }

    public string? Tick { get; set; }

    public double? TickEndPrice { get; set; }

    public byte[]? ValidDate { get; set; }
}

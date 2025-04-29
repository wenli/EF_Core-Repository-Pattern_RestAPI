using System;
using System.Collections.Generic;

namespace BrandApplication.DataAccess.Entities;

public partial class Futures5k
{
    public string? Code { get; set; }

    public byte[]? Ts { get; set; }

    public double? Open { get; set; }

    public double? High { get; set; }

    public double? Low { get; set; }

    public double? Close { get; set; }

    public long? Volume { get; set; }
}

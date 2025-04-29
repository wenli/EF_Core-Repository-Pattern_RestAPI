using System;
using System.Collections.Generic;

namespace BrandApplication.DataAccess.Entities;

public partial class Stocks15k
{
    public long? Code { get; set; }

    public double? Ts { get; set; }

    public long? Close { get; set; }

    public double? High { get; set; }

    public double? Open { get; set; }

    public double? Low { get; set; }

    public double? Volume { get; set; }
}

using System;
using System.Collections.Generic;

namespace BrandApplication.DataAccess.Entities;

public partial class Future
{
    public string? Code { get; set; }

    public string? Symbol { get; set; }

    public string? Name { get; set; }

    public string? Category { get; set; }

    public string? DeliveryMonth { get; set; }

    public string? DeliveryDate { get; set; }

    public string? UnderlyingKind { get; set; }

    public long? Unit { get; set; }

    public double? LimitUp { get; set; }

    public double? LimitDown { get; set; }

    public double? Reference { get; set; }

    public string? UpdateDate { get; set; }

    public string? TargetCode { get; set; }

    public string? UnderlyingCode { get; set; }
}

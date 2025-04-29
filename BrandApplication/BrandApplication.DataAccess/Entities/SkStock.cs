using System;
using System.Collections.Generic;

namespace BrandApplication.DataAccess.Entities;

public partial class SkStock
{
    public long? MarketNo { get; set; }

    public string? Product { get; set; }

    public string? Name { get; set; }

    public string? LastTradeDay { get; set; }

    public string? OrderId { get; set; }
}

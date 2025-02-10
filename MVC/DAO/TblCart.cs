using System;
using System.Collections.Generic;

namespace BO;

public partial class TblCart
{
    public string UserId { get; set; } = null!;

    public string MobileId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double? Price { get; set; }

    public double? Discount { get; set; }

    public string MobileName { get; set; } = null!;

    public int? YearOfProduction { get; set; }

    public int? Quantity { get; set; }

    public string? Images { get; set; }
}

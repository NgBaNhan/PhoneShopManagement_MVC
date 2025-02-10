using System;
using System.Collections.Generic;

namespace BO;

public partial class TblInvDetail
{
    public string InvId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string MobileId { get; set; } = null!;

    public string MobileName { get; set; } = null!;

    public int? Quantity { get; set; }

    public double? Total { get; set; }
}

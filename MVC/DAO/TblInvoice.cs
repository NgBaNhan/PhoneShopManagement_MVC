using System;
using System.Collections.Generic;

namespace BO;

public partial class TblInvoice
{
    public string InvId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public double? Total { get; set; }

    public DateTime? DateBuy { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }
}

using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class AircraftStatusHistory
{
    public int StatusHistoryId { get; set; }

    public int AircraftId { get; set; }

    public string Status { get; set; } = null!;

    public int ChangedByUserId { get; set; }

    public DateTime ChangeDate { get; set; }

    public string? Notes { get; set; }

    public virtual Aircraft Aircraft { get; set; } = null!;

    public virtual User ChangedByUser { get; set; } = null!;
}

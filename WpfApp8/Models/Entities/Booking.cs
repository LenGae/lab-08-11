using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int AircraftId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public decimal TotalCost { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? CancellationReason { get; set; }

    public virtual Aircraft Aircraft { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class Aircraft
{
    public int AircraftId { get; set; }

    public string Model { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public int SeatingCapacity { get; set; }

    public int Range { get; set; }

    public int Speed { get; set; }

    public string? Description { get; set; }

    public decimal BasePricePerHour { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public virtual ICollection<AircraftStatusHistory> AircraftStatusHistories { get; set; } = new List<AircraftStatusHistory>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

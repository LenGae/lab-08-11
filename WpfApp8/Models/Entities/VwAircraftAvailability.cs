using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class VwAircraftAvailability
{
    public int AircraftId { get; set; }

    public string Model { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public int SeatingCapacity { get; set; }

    public decimal BasePricePerHour { get; set; }

    public bool IsAvailable { get; set; }

    public string Status { get; set; } = null!;

    public int? ActiveBookings { get; set; }

    public string AvailabilityStatus { get; set; } = null!;
}

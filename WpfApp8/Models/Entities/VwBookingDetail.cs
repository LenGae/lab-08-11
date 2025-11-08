using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class VwBookingDetail
{
    public int BookingId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public decimal TotalCost { get; set; }

    public string BookingStatus { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public string ClientEmail { get; set; } = null!;

    public string AircraftModel { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public string AircraftType { get; set; } = null!;

    public int? DurationHours { get; set; }
}

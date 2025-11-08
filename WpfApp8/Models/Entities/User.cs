using System;
using System.Collections.Generic;

namespace WpfApp8.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int Role { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<AircraftStatusHistory> AircraftStatusHistories { get; set; } = new List<AircraftStatusHistory>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Role RoleNavigation { get; set; } = null!;
}

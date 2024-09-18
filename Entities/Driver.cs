using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class Driver
{
    public int DriverId { get; set; }

    public int UserId { get; set; }

    public string? LicenseNumber { get; set; }

    public decimal? CurrentLatitude { get; set; }

    public decimal? CurrentLongitude { get; set; }

    public string? Status { get; set; }

    public int? AmbulanceId { get; set; }

    public string? ContactInfo { get; set; }

    public virtual Ambulance? Ambulance { get; set; }

    public virtual ICollection<EmergencyRequest> EmergencyRequests { get; set; } = new List<EmergencyRequest>();

    public virtual User User { get; set; } = null!;
}

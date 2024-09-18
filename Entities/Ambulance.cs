using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class Ambulance
{
    public int AmbulanceId { get; set; }

    public int? AmbulanceTypeId { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? Status { get; set; }

    public decimal? CurrentLatitude { get; set; }

    public decimal? CurrentLongitude { get; set; }

    public string? EquipmentDetails { get; set; }

    public virtual AmbulanceType? AmbulanceType { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual ICollection<EmergencyRequest> EmergencyRequests { get; set; } = new List<EmergencyRequest>();
}

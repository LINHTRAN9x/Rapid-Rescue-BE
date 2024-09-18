using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class EmergencyRequest
{
    public int RequestId { get; set; }

    public int? UserId { get; set; }

    public int? DriverId { get; set; }

    public int? AmbulanceId { get; set; }

    public string? HospitalName { get; set; }

    public string? HospitalAddress { get; set; }

    public string? PickupAddress { get; set; }

    public string? CustomerMobileNumber { get; set; }

    public string? EmergencyType { get; set; }

    public string? Status { get; set; }

    public DateTime? RequestedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Ambulance? Ambulance { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual User? User { get; set; }
}

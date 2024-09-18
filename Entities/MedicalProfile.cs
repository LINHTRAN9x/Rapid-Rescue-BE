using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class MedicalProfile
{
    public int MedicalProfileId { get; set; }

    public int? UserId { get; set; }

    public string? MedicalHistory { get; set; }

    public string? Allergies { get; set; }

    public string? Medications { get; set; }

    public string? BloodType { get; set; }

    public string? OtherNotes { get; set; }

    public byte[] UpdatedAt { get; set; } = null!;

    public virtual User? User { get; set; }
}

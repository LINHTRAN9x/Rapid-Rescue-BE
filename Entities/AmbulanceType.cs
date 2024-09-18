using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class AmbulanceType
{
    public int AmbulanceTypeId { get; set; }

    public string? TypeName { get; set; }

    public string? Size { get; set; }

    public string? Equipment { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Ambulance> Ambulances { get; set; } = new List<Ambulance>();

    public virtual ICollection<ImageGallery> ImageGalleries { get; set; } = new List<ImageGallery>();
}

using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class ImageGallery
{
    public int ImageId { get; set; }

    public int? AmbulanceTypeId { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public virtual AmbulanceType? AmbulanceType { get; set; }
}

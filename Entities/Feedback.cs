using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public string? Message { get; set; }

    public int? Rating { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual User? User { get; set; }
}

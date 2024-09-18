using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int? UserId { get; set; }

    public string? Message { get; set; }

    public string? NotificationType { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public bool? IsRead { get; set; }

    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class Message
{
    public int MessageId { get; set; }

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }

    public string? MessageContent { get; set; }

    public byte[] SentAt { get; set; } = null!;

    public virtual User? Receiver { get; set; }

    public virtual User? Sender { get; set; }
}

using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class ContactUsQuery
{
    public int QueryId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? ContactNumber { get; set; }

    public string? Message { get; set; }

    public byte[] SubmittedAt { get; set; } = null!;
}

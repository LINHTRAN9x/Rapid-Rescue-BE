using System;
using System.Collections.Generic;

namespace Rapid_Rescue.Entities;

public partial class FirstAidInstruction
{
    public int InstructionId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Content { get; set; }

    public string? ImageUrl { get; set; }
}

using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? Name { get; set; }

    public int? Parent { get; set; }

    public int? Levels { get; set; }

    public string? Slug { get; set; }

    public string? NameWithType { get; set; }

    public int? Type { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}

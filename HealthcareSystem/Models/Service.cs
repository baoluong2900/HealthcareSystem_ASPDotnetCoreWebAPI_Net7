using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public int? StaffId { get; set; }

    public string? Description { get; set; }

    public int? StartHours { get; set; }

    public int? StartMinitues { get; set; }

    public int? EndHours { get; set; }

    public int? EndMinitues { get; set; }

    public decimal? Price { get; set; }

    public string? Address { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Staff? Staff { get; set; }
}

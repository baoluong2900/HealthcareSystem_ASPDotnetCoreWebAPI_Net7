using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? UserId { get; set; }

    public int? ServiceId { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public decimal? Price { get; set; }

    public string? Payment { get; set; }

    public DateTime? AppointmentTime { get; set; }

    public int? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? User { get; set; }
}

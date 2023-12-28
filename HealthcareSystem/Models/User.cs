using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserNo { get; set; }

    public int? UserRoleNo { get; set; }

    public string? NationalId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Sex { get; set; }

    public string? Address { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Avatar { get; set; }

    public bool? Active { get; set; }

    public string? SaltPassword { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();
}

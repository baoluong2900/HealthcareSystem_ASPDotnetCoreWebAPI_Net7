using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? StaffNo { get; set; }

    public int? UserRoleNo { get; set; }

    public int? SupplierId { get; set; }

    public string? NationalId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Sex { get; set; }

    public string? Address { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Avatar { get; set; }

    public string? Position { get; set; }

    public string? Qualifications { get; set; }

    public string? LicenseNumber { get; set; }

    public string? Specialization { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? TerminationDate { get; set; }

    public bool? Active { get; set; }

    public string? SaltPassword { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
}

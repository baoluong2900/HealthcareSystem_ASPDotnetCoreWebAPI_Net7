using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public int? LocationNo { get; set; }

    public int? District { get; set; }

    public int? Ward { get; set; }

    public string? SupplierType { get; set; }

    public string? Avatar { get; set; }

    public string? Tin { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Fax { get; set; }

    public string? Website { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? ContactPerson { get; set; }

    public string? TaxId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? LicenseNumber { get; set; }

    public string? ServicesProvided { get; set; }

    public string? Certification { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}

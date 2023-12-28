using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class Account
{
    public int AcoountId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? UserRoleNo { get; set; }

    public string? UserNo { get; set; }

    public DateTime? CreateDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string UserRoleNo { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}

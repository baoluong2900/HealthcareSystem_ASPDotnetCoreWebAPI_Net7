using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class UsersHealthRecordId
{
    public int UsersHealthRecordId1 { get; set; }

    public int? UserId { get; set; }

    public int? HealthRecordId { get; set; }

    public DateTime? CreateDate { get; set; }
}

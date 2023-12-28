using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class WorkSchedule
{
    public int WorkScheduleId { get; set; }

    public int? StaffId { get; set; }

    public DateTime? WorkDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public string? Department { get; set; }

    public string? Notes { get; set; }

    public bool? IsWorking { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Staff? Staff { get; set; }
}

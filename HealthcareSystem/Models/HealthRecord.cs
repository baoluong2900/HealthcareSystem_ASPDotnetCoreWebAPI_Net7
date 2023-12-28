using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class HealthRecord
{
    public int HealthRecordId { get; set; }

    public int? UserId { get; set; }

    public bool? Allergies { get; set; }

    public bool? DiagnosedConditions { get; set; }

    public bool? CurrentMedications { get; set; }

    public bool? SportsPlayed { get; set; }

    public int? DailyWaterIntake { get; set; }

    public bool? HairLoss { get; set; }

    public string? UrineColor { get; set; }

    public bool? UrineSmell { get; set; }

    public string? StoolCharacteristics { get; set; }

    public decimal? Height { get; set; }

    public decimal? WaistCircumference { get; set; }

    public bool? Overweight { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? User { get; set; }
}

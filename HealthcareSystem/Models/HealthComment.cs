using System;
using System.Collections.Generic;

namespace HealthcareSystem.Models;

public partial class HealthComment
{
    public int HealthCommentId { get; set; }

    public int? HealthRecordId { get; set; }

    public int? ReviewId { get; set; }

    public string? CommentText { get; set; }

    public string? Recommendation { get; set; }

    public int? CommentedBy { get; set; }

    public DateTime? CommentedAt { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}

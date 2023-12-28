

namespace HealthcareSystem.ModelViews
{
    public class ServiceView
    {
        public partial class ServiceRequest
        {
            public string? ServiceName { get; set; } = null!;

            public int? StaffId { get; set; }

            public string? Description { get; set; }

            public int? StartHours { get; set; }

            public int? StartMinitues { get; set; }

            public int? EndHours { get; set; }

            public int? EndMinitues { get; set; }
            public string? Address { get; set; }

            public decimal? Price { get; set; }

        }
        public partial class ServiceReponse : MessageView
        {
            public bool? IsError { get; set; }
        }
    }


}

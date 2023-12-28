
namespace HealthcareSystem.ModelViews
{
    public class AppointmentView
    {
        public partial class AppointmentRequest
        {
            public int? UserId { get; set; }

            public int? ServiceId { get; set; }

            public string? Address { get; set; }

            public string? Description { get; set; }

            public decimal? Price { get; set; }

            public string? Payment { get; set; }

            public DateTime? AppointmentTime { get; set; }

            public int? Status { get; set; }
        }

        public partial class AppointmentReponse : MessageView
        {
            public int AppointmentId { get; set; }

            public string? ServiceName { get; set; }
            public decimal? Price { get; set; }


            public DateTime AppointmentTime { get; set; }

            public string Status { get; set; }
        }
    }
}

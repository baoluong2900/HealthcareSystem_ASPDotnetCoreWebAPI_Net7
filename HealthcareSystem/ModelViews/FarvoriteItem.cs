namespace HealthcareSystem.ModelViews
{
    public class FarvoriteItem
    {

        public partial class FarvoriteItemReponse 
        {
            public int AppointmentId { get; set; }

            public string? Title { get; set; }
            public decimal? Price { get; set; }

            public string? Date { get; set; }

            public int? Status { get; set; }

            public int? Payment { get; set; }
        }
    }
}

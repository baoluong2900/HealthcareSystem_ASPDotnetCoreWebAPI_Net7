

using HealthcareSystem.Models;
using static HealthcareSystem.ModelViews.FarvoriteItem;

namespace HealthcareSystem.ModelViews
{
    public partial class LoginRequest
    {
        public string? UserName { get; set; }
        public string? PassWord { get; set; }

        //public int? UserRoleNo { get; set; }
    }

    public partial class LoginReponse: MessageView
    {
        public object User { get; set; } = null!;
        public List<FarvoriteItemReponse>? Appointments { get; set; }
        public List<Service>? Services { get; set; }



        public bool? IsLoggedIn { get; set; }
        public bool? IsError { get; set; } 

    }
}

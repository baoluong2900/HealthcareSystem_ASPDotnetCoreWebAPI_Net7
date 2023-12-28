using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.ModelViews
{
    public partial class RegisterRequest
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public int? UserRoleNo { get; set; }

    }
    public partial class RegisterReponse: MessageView
    {
        public bool? IsError { get; set; }
    }
}

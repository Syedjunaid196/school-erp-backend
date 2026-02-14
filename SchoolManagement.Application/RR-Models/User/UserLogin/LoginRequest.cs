namespace SchoolManagement.Application.RR_Models.User.UserLogin
{
    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        //public string? DeviceName { get; set; }
        //public string? DeviceId { get; set; }
        //public string? IpAddress { get; set; }
        //public string? UserAgent { get; set; }
        //public bool RememberMe { get; set; } = false;
    }
}

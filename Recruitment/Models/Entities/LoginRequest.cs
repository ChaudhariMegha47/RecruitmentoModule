namespace Recruitment.Models.Entities
{
    public class LoginRequest
    {
        public long Login_id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

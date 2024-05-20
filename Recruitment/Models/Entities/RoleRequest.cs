namespace Recruitment.Models.Entities
{
    public class RoleRequest
    {
        public long RoleId { get; set; }
        public String Rolename { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

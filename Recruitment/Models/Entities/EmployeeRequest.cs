namespace Recruitment.Models.Entities
{
    public class EmployeeRequest
    {
        public long Emp_id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Email { get; set; }
        public string Contactno { get; set; }
        public string Designation { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool IsActive { get; set; }
    }
}

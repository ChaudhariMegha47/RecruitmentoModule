namespace Recruitment.Models.Entities
{
    public class ApplicationFormRequest
    {
        public long Candidate_id { get; set; }
        public long Job_id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Dateofbirth { get; set; }
        public int Age { get; set; }
        public long Contactno { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string qualification { get; set; }
        public string Experience { get; set; }
        public IFormFile Candidate_image { get; set; }
        public IFormFile Resume_image { get; set; }
        public string Result { get; set; }
        public bool IsActive { get; set; }
    }
}

namespace Recruitment.Models.Entities
{
    public class ListofCandidateRequest
    {
        public long Candidate_id { get; set; }
        public long Job_id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly Dateofbirth { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Contactno { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public string Result { get; set; }
        public string Resume_image { get; set; }
        public string Candidate_image { get; set; }
        public bool IsActive { get; set; }
    }
}

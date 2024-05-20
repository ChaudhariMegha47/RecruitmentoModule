namespace Recruitment.Models.Entities
{
    public class CreatejobRequest
    {
        public long JobId { get; set; }
        public string Title { get; set; }
        public string Jobdescription { get; set; }
        public long Qualification { get; set; }
        public long Experience { get; set; }
        public int Age { get; set; }
        public DateTime Validupto { get; set; }
        public int Vacancies { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

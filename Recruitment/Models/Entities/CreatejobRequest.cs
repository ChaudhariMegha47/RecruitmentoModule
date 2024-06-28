
namespace Recruitment.Models.Entities
{
    public class CreatejobRequest
    {
        public long JobId { get; set; }
        public string Title { get; set; }
        public string Jobposition { get; set; }
        public long qualification { get; set; }
        public string Jobtype { get; set; }
        public string Jobdescription { get; set; }
        public int Vacancies { get; set; }
        public long Experience { get; set; }
        public DateTime Validupto { get; set; }
        public DateTime Createddate { get; set; }
        public long StartSalary { get; set; }
        public long EndSalary { get; set; }
        public string Createdby { get; set; }
        public bool IsActive { get; set; } = true;
    }

}

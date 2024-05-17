namespace Recruitment.Models.Entities
{
    public class ExperienceRequest
    {
        public long ExpId { get; set; }
        public String Experience { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

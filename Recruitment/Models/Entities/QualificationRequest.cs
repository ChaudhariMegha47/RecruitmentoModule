namespace Recruitment.Models.Entities
{
    public class QualificationRequest
    {
        public long EduId { get; set; }
        public string QuaName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model.Service
{
    public class ApplicationformModel
    {
        public long candidate_id { get; set; }
        public long job_id { get; set; }
        public string title { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public DateOnly dateofbirth { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int contactno { get; set; }
        public string experience { get; set; }
        public string qualification { get; set; }
        public string result { get; set; }
        public string resume_image { get; set; }
        public string candidate_image { get; set; }
        public bool IsActive { get; set; }
    }
}

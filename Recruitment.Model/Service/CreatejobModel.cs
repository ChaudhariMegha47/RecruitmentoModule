using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model.Service
{
    public class CreatejobModel
    {
        public long job_id { get; set; }
        public String title { get; set; }
        public String jobdescription { get; set; }
        public long qualification { get; set; }
        public string strqualification { get; set; }
        public string experience { get; set; }
        public string strCreateDate { get; set; }
        public int age { get; set; }
        public DateTime validupto { get; set; }
        public int vacancies { get; set; }
        public DateTime createddate { get; set; }
        public string createdby { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model.Service
{
    public class ExperienceModel
    {
        public long exp_id { get; set; }
        public String experience { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

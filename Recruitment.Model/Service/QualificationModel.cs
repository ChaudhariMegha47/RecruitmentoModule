using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model.Service
{
    public class QualificationModel
    {
        public int? edu_id { get; set; }
        public string qualificationname { get; set; }
        public bool IsActive { get; set; } = true;
    }
}


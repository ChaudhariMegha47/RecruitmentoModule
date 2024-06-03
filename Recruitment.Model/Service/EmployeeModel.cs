using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model.Service
{
    public class EmployeeModel
    {
        public long emp_id { get; set; }
        public string title { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public DateTime strdateofbirth { get; set; }
        public string email { get; set; }
        public string contactno { get; set; }
        public string designation { get; set; }
        public bool IsActive { get; set; }
    }
}

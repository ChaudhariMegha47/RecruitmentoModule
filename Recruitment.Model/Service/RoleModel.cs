using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model.Service
{
    public class RoleModel
    {
        public long role_id { get; set; }
        public String rolename { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

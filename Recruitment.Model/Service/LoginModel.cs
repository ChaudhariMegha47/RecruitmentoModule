using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Model.Service
{
    public class LoginModel
    {
        public long login_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

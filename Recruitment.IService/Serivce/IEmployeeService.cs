using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetList();
        EmployeeModel Get(long id);

        JsonResponseModel AddOrUpdate(EmployeeModel model);
        JsonResponseModel Delete(long EmpId);
    }
}

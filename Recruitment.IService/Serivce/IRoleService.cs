using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface IRoleService
    {
        List<RoleModel> GetList();
        RoleModel Get(long id);

        JsonResponseModel AddOrUpdate(RoleModel model);
        JsonResponseModel Delete(long RoleId);
    }
}

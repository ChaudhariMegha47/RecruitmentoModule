using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface ILoginService
    {
        List<LoginModel> GetList();
        LoginModel Get(long id);

        JsonResponseModel AddOrUpdate(LoginModel model);
        JsonResponseModel Delete(long LoginId);
    }
}

using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface ICreatejobService
    {
        List<CreatejobModel> GetList();
        CreatejobModel Get(long id);

        JsonResponseModel AddOrUpdate(CreatejobModel model);
        JsonResponseModel Delete(long JobId);
    }
}

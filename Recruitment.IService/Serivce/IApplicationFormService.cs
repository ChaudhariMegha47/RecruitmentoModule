using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface IApplicationFormService
    {
        List<ApplicationFormModel> GetList();
        ApplicationFormModel Get(long id);

        JsonResponseModel AddOrUpdate(ApplicationFormModel model);
        JsonResponseModel Delete(long CandidateId);
    }
}

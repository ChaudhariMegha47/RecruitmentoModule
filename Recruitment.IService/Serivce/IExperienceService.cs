using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface IExperienceService
    {
        List<ExperienceModel> GetList();
        ExperienceModel Get(long id);

        JsonResponseModel AddOrUpdate(ExperienceModel model);
        JsonResponseModel Delete(long ExpId);
    }
}

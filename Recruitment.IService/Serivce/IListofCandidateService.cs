using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface IListofCandidateService
    {
        List<ListofCandidateModel> GetList();
        ListofCandidateModel Get(long id);

        JsonResponseModel AddOrUpdate(ListofCandidateModel model);
        JsonResponseModel Delete(long CandidateId);
    }
}

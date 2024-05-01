using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface IQualificationService
    {
        List<QualificationModel> GetList();
        QualificationModel Get(long id);

        JsonResponseModel AddOrUpdate(QualificationModel model);
        JsonResponseModel Delete(long EduId);
    }
}

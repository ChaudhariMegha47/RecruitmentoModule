﻿using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.IService.Serivce
{
    public interface IApplicationform
    {
        List<ApplicationformModel> GetList();
        ApplicationformModel Get(long id);

        JsonResponseModel AddOrUpdate(ApplicationformModel model);
        JsonResponseModel Delete(long CandidateId);
    }
}

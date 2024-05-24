using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Services.Service
{
    public class CreatejobService : ICreatejobService
    {
        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public CreatejobService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        public JsonResponseModel AddOrUpdate(CreatejobModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_id", model.job_id);
                dictionary.Add("p_Title", model.title);
                dictionary.Add("p_Jobdescription", model.jobdescription);
                dictionary.Add("p_Qualification", model.qualification);
                dictionary.Add("p_Experience", model.experience);
                dictionary.Add("p_Age", model.age);
                dictionary.Add("p_Validupto", model.validupto);
                dictionary.Add("p_Vacancies", model.vacancies);
                dictionary.Add("p_Createdby", model.createdby);
                dictionary.Add("p_IsActive", model.IsActive);

                // Assuming dapperConnection is your Dapper connection instance
                //var data = dapperConnection.GetListResult("InsertOrUpdateEmployee",  CommandType.StoredProcedure, dictionary).ToList();
                var data = dapperConnection.GetListResult<long>("InsertOrUpdateJob", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.job_id == 0)
                {
                    response.strMessage = "Register successfully";
                }
                else
                {
                    response.strMessage = "Record updated successfully";
                }
                response.isError = false;
                response.type = PopupMessageType.success.ToString();
                response.result = data;

                response.Success = true;
                response.Message = "Job added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating Job.", ex.ToString(), "CreatejobService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating job.";
            }
            return response;
        }

        public JsonResponseModel Delete(long JobId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_id", JobId);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<int>("RemoveJob", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Job deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Job Name with ID {JobId}.", ex.ToString(), "CreatejobService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting Job.";
            }
            return response;
        }

        public CreatejobModel Get(long id)
        {
            try
            {
                var dataModel = GetList().Where(x => x.job_id == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll job id", ex.ToString(), "CreatejobService", "Get");
                return null;
            }
        }

        public List<CreatejobModel> GetList()
        {
            _ = new List<CreatejobModel>();
            List<CreatejobModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<CreatejobModel>("Proc_GetAllJobList", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Proc_GetAllJobList", ex.ToString(), "CreatejobService", "GetList");
                lst = null;
            }
            return lst;
        }
    }
}

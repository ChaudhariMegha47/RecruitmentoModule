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
    public class ExperienceService : IExperienceService
    {

        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public ExperienceService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        public JsonResponseModel AddOrUpdate(ExperienceModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("id", model.exp_id);
                dictionary.Add("experienceyear", model.experience);
                dictionary.Add("IsActive", model.IsActive);

                // Assuming dapperConnection is your Dapper connection instance
                //var data = dapperConnection.GetListResult("InsertOrUpdateEmployee",  CommandType.StoredProcedure, dictionary).ToList();
                var data = dapperConnection.GetListResult<long>("InsertOrUpdateExperience", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.exp_id == 0)
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
                response.Message = "Experience Name added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating Experience Name.", ex.ToString(), "ExperienceService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating Experience Name.";
            }
            return response;
        }

        public JsonResponseModel Delete(long ExpId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("id", ExpId);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<int>("RemoveExperience", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Experience Name deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Experience Name with ID {ExpId}.", ex.ToString(), "ExperienceService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting Experience Name.";
            }
            return response;
        }

        public ExperienceModel Get(long id)
        {
            try
            {
                var dataModel = GetList().Where(x => x.exp_id == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll Experience Name id", ex.ToString(), "ExperienceService", "Get");
                return null;
            }
        }

        public List<ExperienceModel> GetList()
        {
            _ = new List<ExperienceModel>();
            List<ExperienceModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<ExperienceModel>("Proc_GetAllExperienceList", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Proc_GetAllExperienceList", ex.ToString(), "ExperienceService", "GetList");
                lst = null;
            }
            return lst;
        }
    }

 }


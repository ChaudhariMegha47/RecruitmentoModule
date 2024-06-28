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
    public class ListofCandidateService : IListofCandidateService
    {
        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public ListofCandidateService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        public JsonResponseModel AddOrUpdate(ListofCandidateModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_id", model.candidate_id);
                dictionary.Add("p_jobid", model.job_id);
                dictionary.Add("p_Title", model.title);
                dictionary.Add("p_Firstname", model.firstname);
                dictionary.Add("p_middlename", model.middlename);
                dictionary.Add("p_Lastname", model.lastname);
                dictionary.Add("p_Dateofbirth", model.dateofbirth);
                dictionary.Add("p_age", model.age);
                dictionary.Add("p_Contactno", model.contactno);
                dictionary.Add("p_Email", model.email);
                dictionary.Add("p_Gender", model.gender);
                dictionary.Add("p_address", model.address);
                dictionary.Add("p_qualification", model.qualification);
                dictionary.Add("p_experience", model.experience);
                dictionary.Add("p_Image_Path", model.candidate_image);
                dictionary.Add("p_resume_image", model.resume_image);
                dictionary.Add("p_result", model.result);
                dictionary.Add("p_IsActive", model.IsActive);

                // Assuming dapperConnection is your Dapper connection instance
                //var data = dapperConnection.GetListResult("InsertOrUpdateEmployee",  CommandType.StoredProcedure, dictionary).ToList();
                var data = dapperConnection.GetListResult<long>("InsertOrUpdateListofcandidate", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.candidate_id == 0)
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
                response.Message = "Form added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating Job.", ex.ToString(), "listofCandidateService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating job.";
            }
            return response;
        }

        public JsonResponseModel Delete(long CandidateId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_id", CandidateId);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<int>("RemoveListofcandidate", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Job Name with ID {CandidateId}.", ex.ToString(), "listofCandidateService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting Job.";
            }
            return response;
        }

        public ListofCandidateModel Get(long id)
        {
            try
            {
                var dataModel = GetList().Where(x => x.candidate_id == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll Candidate id", ex.ToString(), "listofCandidateService", "Get");
                return null;
            }
        }

        public List<ListofCandidateModel> GetList()
        {
            _ = new List<ListofCandidateModel>();
            List<ListofCandidateModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<ListofCandidateModel>("Proc_GetAllListofcandidate", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Proc_GetAllJobList", ex.ToString(), "listofCandidateService", "GetList");
                lst = null;
            }
            return lst;
        }
    }
}

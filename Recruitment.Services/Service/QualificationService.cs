using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using System.Data;

namespace Recruitment.Services.Service
{
    public class QualificationService : IQualificationService
    {
        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public QualificationService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion


        public JsonResponseModel AddOrUpdate(QualificationModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("id", model.edu_id);
                dictionary.Add("Qualificationname", model.qualificationname);
                dictionary.Add("IsActive", model.IsActive);
              

                // Assuming dapperConnection is your Dapper connection instance
                //var data = dapperConnection.GetListResult("InsertOrUpdateEmployee",  CommandType.StoredProcedure, dictionary).ToList();
                var data = dapperConnection.GetListResult<long>("InsertOrUpdateQualification", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.edu_id == 0)
                {
                    response.strMessage = "Add successfully";
                }
                else
                {
                    response.strMessage = "Record updated successfully";
                }
                response.isError = false;
                response.type = PopupMessageType.success.ToString();
                response.result = data;

                response.Success = true;
                response.Message = "Qualification added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating employee.", ex.ToString(), "QualificationService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating employee.";
            }
            return response;
        }




        public JsonResponseModel Delete(long Edu_id)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("id", Edu_id);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<long>("RemoveQualification", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Qualification deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Qualification Name with ID {Edu_id}.", ex.ToString(), "QualificationService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting Qualification Name.";
            }
            return response;
        }


        public QualificationModel Get(long id)
        {
            try
            {
                var dataModel = GetList().Where(x => x.edu_id == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll Qualification Name id", ex.ToString(), "QualificationService", "Get");
                return null;
            }
        }

        public List<QualificationModel> GetList()
        {
            _ = new List<QualificationModel>();
            List<QualificationModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<QualificationModel>("Proc_GetAllQualificationList", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Proc_GetAllQualificationList", ex.ToString(), "QualificationService", "GetList");
                lst = null;
            }
            return lst;
        }
    }
}



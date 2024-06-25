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
    public class LoginService : ILoginService
    {
        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public LoginService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion


        public JsonResponseModel AddOrUpdate(LoginModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_user_id", model.login_id);
                dictionary.Add("v_username", model.username);
                dictionary.Add("v_password", model.password);
                dictionary.Add("p_isactive", model.IsActive);


                // Assuming dapperConnection is your Dapper connection instance
                //var data = dapperConnection.GetListResult("InsertOrUpdateEmployee",  CommandType.StoredProcedure, dictionary).ToList();
                var data = dapperConnection.GetListResult<long>("InsertorUpdateUser", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.login_id == 0)
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




        public JsonResponseModel Delete(long login_id)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("id", login_id);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<long>("RemoveQualification", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Qualification deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Qualification Name with ID {login_id}.", ex.ToString(), "QualificationService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting Qualification Name.";
            }
            return response;
        }


        public LoginModel Get(long id)
        {
            try
            {
                var dataModel = GetList().Where(x => x.login_id == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll Qualification Name id", ex.ToString(), "QualificationService", "Get");
                return null;
            }
        }

        public List<LoginModel> GetList()
        {
            _ = new List<LoginModel>();
            List<LoginModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<LoginModel>("Proc_GetAllQualificationList", CommandType.StoredProcedure).ToList();
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

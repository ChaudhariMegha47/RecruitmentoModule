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
    public class EmployeeService : IEmployeeService
    {
        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public EmployeeService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        public JsonResponseModel AddOrUpdate(EmployeeModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_id", model.emp_id);
                dictionary.Add("p_Title", model.title);
                dictionary.Add("p_Firstname", model.firstname);
                dictionary.Add("p_Lastname", model.lastname);
                dictionary.Add("p_Gender", model.gender);
                dictionary.Add("p_Dateofbirth", model.dateofbirth);
                dictionary.Add("p_Email", model.email);
                dictionary.Add("p_Contactno", model.contactno);
                dictionary.Add("p_Designation", model.designation);
                dictionary.Add("p_IsActive", model.IsActive);

                // Assuming dapperConnection is your Dapper connection instance
                //var data = dapperConnection.GetListResult("InsertOrUpdateEmployee",  CommandType.StoredProcedure, dictionary).ToList();
                var data = dapperConnection.GetListResult<long>("InsterOrUpdateEmployee", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.emp_id == 0)
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
                response.Message = "Employee added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating Employee.", ex.ToString(), "EmployeeService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating Employee.";
            }
            return response;
        }

        public JsonResponseModel Delete(long EmpId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_id", EmpId);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<int>("RemoveEmployee", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Employee deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Job Name with ID {EmpId}.", ex.ToString(), "EmployeeService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting Employee.";
            }
            return response;
        }

        public EmployeeModel Get(long id)
        {
            try
            {
                var dataModel = GetList().Where(x => x.emp_id == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll Employee id", ex.ToString(), "EmployeeService", "Get");
                return null;
            }
        }

        public List<EmployeeModel> GetList()
        {
            _ = new List<EmployeeModel>();
            List<EmployeeModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<EmployeeModel>("Proc_GetAllEmployee", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Proc_GetAllEmployee", ex.ToString(), "EmployeeService", "GetList");
                lst = null;
            }
            return lst;
        }
    }
}

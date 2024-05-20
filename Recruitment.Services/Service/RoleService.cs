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
    public class RoleService : IRoleService
    {
        #region Constants
        private readonly DapperConnection dapperConnection;
        #endregion

        #region Constructor
        public RoleService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        public JsonResponseModel AddOrUpdate(RoleModel model)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("id", model.role_id);
                dictionary.Add("roleName", model.rolename);
                dictionary.Add("IsActive", model.IsActive);

                // Assuming dapperConnection is your Dapper connection instance
                //var data = dapperConnection.GetListResult("InsertOrUpdateEmployee",  CommandType.StoredProcedure, dictionary).ToList();
                var data = dapperConnection.GetListResult<long>("InsertOrUpdateRole", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.role_id == 0)
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
                response.Message = "Role Name added/updated successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error adding/updating Role", ex.ToString(), "RoleService", "AddOrUpdate");
                response.Success = false;
                response.Message = "An error occurred while adding/updating Experience Name.";
            }
            return response;
        }

        public JsonResponseModel Delete(long RoleId)
        {
            JsonResponseModel response = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("id", RoleId);

                // Your logic for deleting employee here
                dapperConnection.GetListResult<int>("RemoveRole", CommandType.StoredProcedure, dictionary);
                response.Success = true;
                response.isError = false;
                response.Message = "Role  deleted successfully.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Error($"Error deleting Role Name with ID {RoleId}.", ex.ToString(), "RoleService", "Delete");
                response.Success = false;
                response.Message = "An error occurred while deleting Role Name.";
            }
            return response;
        }

        public RoleModel Get(long id)
        {
            try
            {
                var dataModel = GetList().Where(x => x.role_id == id).FirstOrDefault();
                return dataModel;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into GetAll Role Name id", ex.ToString(), "RoleService", "Get");
                return null;
            }
        }

        public List<RoleModel> GetList()
        {
            _ = new List<RoleModel>();
            List<RoleModel> lst;
            try
            {
                lst = dapperConnection.GetListResult<RoleModel>("Proc_GetAllRoleList", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into Proc_GetAllRoleList", ex.ToString(), "RoleService", "GetList");
                lst = null;
            }
            return lst;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;

namespace Recruitment.Controllers
{
    public class RoleController : Controller
    {
        private IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/Role/GetRoleData")]
        public JsonResult GetRoleData()
        {
            try
            {
                var lsdata = roleService.GetList();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                return Json("");
            }

        }

        [HttpPost]
        [Route("/Role/SaveRoleData")]
        public JsonResponseModel SaveRoleData(RoleRequest roleRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                RoleModel model = new RoleModel();
                model.role_id = roleRequest.RoleId;
                model.rolename = roleRequest.Rolename;
                model.IsActive = roleRequest.IsActive;

                // Call the service method to add or update the employee
                var result = roleService.AddOrUpdate(model);
                obj.result = result.result;
                obj.Message = "Record saved successfully";
            }
            catch (Exception ex)
            {
                // Handle error
                obj.result = false;
                obj.Message = "An error occurred: " + ex.Message;
            }

            return obj;
        }

        [HttpPost]
        [Route("/Role/GetRoleDetails")]
        public JsonResponseModel GetRoleDetails(long roleid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var role = roleService.Get(roleid);
                if (role != null)
                {
                    // Populate QualificationRequest object
                    RoleRequest exp = new RoleRequest();
                    exp.RoleId = role.role_id;
                    exp.Rolename = role.rolename;
                    exp.IsActive = role.IsActive;

                    // Populate JsonResponseModel
                    objreturn.strMessage = "";
                    objreturn.isError = false;

                    objreturn.result = exp;
                }
                else
                {
                    objreturn.strMessage = "Enter Valid Id.";
                    objreturn.isError = true;
                    objreturn.type = PopupMessageType.error.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
                objreturn.strMessage = "An error occurred.";
                objreturn.isError = true;
                objreturn.type = PopupMessageType.error.ToString();
            }
            return objreturn;
        }

        [HttpPost]
        [Route("/Role/DeleteRoleData")]
        public JsonResponseModel DeleteRoleData(long roleid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var roleservice = new RoleService(); // Instantiate your service or repository class
                objreturn = roleservice.Delete(roleid);
            }
            catch (Exception ex)
            {
                // Handle error
                return objreturn;
            }
            return objreturn;
        }
    }
}

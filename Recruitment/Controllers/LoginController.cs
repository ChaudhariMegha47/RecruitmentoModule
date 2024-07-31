using Microsoft.AspNetCore.Mvc;
using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;

namespace Recruitment.Controllers
{
    public class LoginController : Controller
    {

        private ILoginService loginService;

        public LoginController(ILoginService loginService)
            {
                this.loginService = loginService;
            }

            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }


            //[HttpGet]
            //public IActionResult QualificationList()
            //{
            //    var qualification = qualificationservice.GetList();
            //    return Json(qualification);
            //}


            [HttpPost]
            [Route("/Login/GetLoginData")]
            public JsonResult GetLoginData()
            {
                try
                {
                    var lsdata = loginService.GetList();

                    return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
                }
                catch (Exception ex)
                {
                    ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                    return Json("");
                }

            }

            [HttpPost]
            [Route("/Login/SaveLoginData")]
            public JsonResponseModel SaveLoginData(LoginRequest loginRequest)
            {
                JsonResponseModel obj = new JsonResponseModel();
                try
                {
                    LoginModel model = new LoginModel();
                    model.login_id = loginRequest.Login_id;
                    model.username = loginRequest.UserName;
                    model.password = loginRequest.Password;
                    model.IsActive = loginRequest.IsActive;

                    // Call the service method to add or update the employee
                    var result = loginService.AddOrUpdate(model);
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
            [Route("/Login/GetLoginDetails")]
            public JsonResponseModel GetLoginDetails(long loginid)
            {
                JsonResponseModel objreturn = new JsonResponseModel();
                try
                {
                    var login = loginService.Get(loginid);
                    if (login != null)
                    {
                        // Populate QualificationRequest object
                        LoginRequest qua = new LoginRequest();
                        qua.Login_id = login.login_id;
                        qua.UserName = login.username;
                        qua.Password = login.password;
                        qua.IsActive = login.IsActive;

                        // Populate JsonResponseModel
                        objreturn.strMessage = "";
                        objreturn.isError = false;

                        objreturn.result = qua;
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
            [Route("/Login/DeleteLoginData")]
            public JsonResponseModel DeleteLoginData(long loginid)
            {
                JsonResponseModel objreturn = new JsonResponseModel();
                try
                {
                    var loginService = new LoginService(); // Instantiate your service or repository class
                    objreturn = loginService.Delete(loginid);
                }
                catch (Exception)
                {
                    // Handle error
                    return objreturn;
                }
                return objreturn;
            }




            [HttpPost]
            [Route("/Qualification/AddOrUpdate")]
            public JsonResponseModel AddOrUpdate(LoginModel loginModel)
            {
                JsonResponseModel obj = new JsonResponseModel();

                try
                {
                LoginModel model = new LoginModel();
                    model.login_id = loginModel.login_id;
                    model.username = loginModel.username;
                    model.password = loginModel.password;
                // Call the service method to add or update the employee
                var result = loginService.AddOrUpdate(model);
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
    }
}


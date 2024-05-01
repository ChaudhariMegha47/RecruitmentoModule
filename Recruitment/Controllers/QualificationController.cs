using Employee.Common;
using Microsoft.AspNetCore.Mvc;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;
using System;
using System.Web;

namespace Recruitment.Controllers
{
    public class QualificationController : Controller
    {
        private IQualificationService qualificationservice;

        public QualificationController(IQualificationService qualificationservice)
        {
            this.qualificationservice = qualificationservice;
        }

      
        [HttpPost]
        [Route("/Qualification/GetQualificationDetails")]
        public JsonResponseModel GetQualificationDetails(long QuaId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                //id = HttpUtility.UrlDecode(id).Replace('+', '-');
                //langId = HttpUtility.UrlDecode(langId).Replace('+', '-');

                var qualification = qualificationservice.Get(QuaId);
                if (qualification != null)
                {
                    objreturn.strMessage = "";
                    objreturn.isError = false;
                    objreturn.result = qualificationservice.Get(QuaId);
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
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
            }
            return objreturn;
        }

        
        [HttpPost]
        [Route("/Qualification/DeleteQualificationData")]
        public JsonResponseModel DeleteQualificationData(long QuaId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var qualificationservice = new QualificationService(); // Instantiate your service or repository class
                objreturn = qualificationservice.Delete(QuaId);
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
                objreturn.strMessage = "Record not deleted, Try again";
                objreturn.isError = true;
                objreturn.type = PopupMessageType.error.ToString();
            }
            return objreturn;
        }

        [HttpGet]
        public IActionResult QualificationMaster()
        {
            return View();
        }

        [HttpPost]
        [Route("/Qualification/GetQualificationData")]
        public JsonResult GetQualificationData()
        {
            try
            {
                var lsdata = qualificationservice.GetList();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                return Json("");
            }

        }

        [HttpPost]
        [Route("/Qualification/AddOrUpdate")]
        public JsonResponseModel AddOrUpdate(QualificationModel qualificationModel)
        {
            JsonResponseModel obj = new JsonResponseModel();

            try
            {
                QualificationModel model = new QualificationModel();
                model.edu_id = qualificationModel.edu_id;
                model.qualificationname = qualificationModel.qualificationname;
                // Call the service method to add or update the employee
                var result = qualificationservice.AddOrUpdate(model);
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
        public JsonResponseModel QuaDelete(long qualificationId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var qualificationservice = new QualificationService(); // Instantiate your service or repository class
                objreturn = qualificationservice.Delete(qualificationId); // Assuming you have a method to delete employee data
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

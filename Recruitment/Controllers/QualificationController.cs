using Recruitment.Common;
using Microsoft.AspNetCore.Mvc;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;
using System;
using System.Net.Http;
using System.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public JsonResponseModel GetQualificationDetails(long eduid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var qualification = qualificationservice.Get(eduid);
                if (qualification != null)
                {
                    // Populate QualificationRequest object
                    QualificationRequest qua = new QualificationRequest();
                    qua.EduId = qualification.edu_id;
                    qua.QuaName = qualification.qualificationname;
                    qua.IsActive = qualification.IsActive;

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
        [Route("/Qualification/SaveQualificationData")]
        public JsonResponseModel SaveQualificationData(QualificationRequest qualificationModel)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                QualificationModel model = new QualificationModel();
                // model.edu_id = qualificationModel.EduId;
                model.qualificationname = qualificationModel.QuaName;
                model.IsActive = qualificationModel.IsActive;

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
        [Route("/Qualification/DeleteQualificationData")]
        public JsonResponseModel DeleteQualificationData(long eduid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var qualificationservice = new QualificationService(); // Instantiate your service or repository class
                objreturn = qualificationservice.Delete(eduid);
            }
            catch (Exception ex)
            {
                // Handle error
                return objreturn;
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
    }
}




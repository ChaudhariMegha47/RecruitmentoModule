using Employee.Common;
using Microsoft.AspNetCore.Mvc;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;

namespace Recruitment.Controllers
{
    public class ExperienceController : Controller
    {
        private IExperienceService experienceservice;

        public ExperienceController(IExperienceService experienceservice)
        {
          this.experienceservice = experienceservice;
        }


        [HttpPost]
        [Route("/Experience/GetExperienceDetails")]
        public JsonResponseModel GetExperienceDetails(long ExpId)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                //id = HttpUtility.UrlDecode(id).Replace('+', '-');
                //langId = HttpUtility.UrlDecode(langId).Replace('+', '-');

                var qualification = experienceservice.Get(ExpId);
                if (qualification != null)
                {
                    objreturn.strMessage = "";
                    objreturn.isError = false;
                    objreturn.result = experienceservice.Get(ExpId);
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
        [Route("/Experience/DeleteExperienceData")]
        public JsonResponseModel DeleteExperienceData(long QuaId)
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
        public IActionResult Experiencemaster()
        {
            return View();
        }

        [HttpPost]
        [Route("/Experience/GetExperienceData")]
        public JsonResult GetExperienceData()
        {
            try
            {
                var lsdata = experienceservice.GetList();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                return Json("");
            }

        }


        [HttpPost]
        [Route("/Experience/AddOrUpdate")]
        public JsonResponseModel AddOrUpdate(ExperienceModel experienceModel)
        {
            JsonResponseModel obj = new JsonResponseModel();

            try
            {
                ExperienceModel model = new ExperienceModel();
                model.exp_id = experienceModel.exp_id;
                model.experienceyear = experienceModel.experienceyear;
                // Call the service method to add or update the employee
                var result = experienceservice.AddOrUpdate(model);
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
                objreturn = experienceservice.Delete(qualificationId); // Assuming you have a method to delete employee data
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

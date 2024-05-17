using Microsoft.AspNetCore.Mvc;
using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;

namespace Recruitment.Controllers
{
    public class ExperienceController : Controller
    {
        private IExperienceService experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/Experience/GetExperienceData")]
        public JsonResult GetExperienceData()
        {
            try
            {
                var lsdata = experienceService.GetList();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                return Json("");
            }

        }

        [HttpPost]
        [Route("/Experience/SaveExperienceData")]
        public JsonResponseModel SaveExperienceData(ExperienceRequest experienceRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                ExperienceModel model = new ExperienceModel();
                model.exp_id = experienceRequest.ExpId;
                model.experience = experienceRequest.Experience;
                model.IsActive = experienceRequest.IsActive;

                // Call the service method to add or update the employee
                var result = experienceService.AddOrUpdate(model);
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
        [Route("/Experience/GetExperienceDetails")]
        public JsonResponseModel GetExperienceDetails(long expid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var experience = experienceService.Get(expid);
                if (experience != null)
                {
                    // Populate QualificationRequest object
                    ExperienceRequest exp = new ExperienceRequest();
                    exp.ExpId = experience.exp_id;
                    exp.Experience = experience.experience;
                    exp.IsActive = experience.IsActive;

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
        [Route("/Experience/DeleteExperienceData")]
        public JsonResponseModel DeleteExperienceData(long expid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var experienceService = new ExperienceService(); // Instantiate your service or repository class
                objreturn = experienceService.Delete(expid);
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

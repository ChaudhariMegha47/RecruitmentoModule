using Microsoft.AspNetCore.Mvc;
using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;

namespace Recruitment.Controllers
{
    public class CreatejobController : Controller
    {
        private ICreatejobService createjobService;
        public CreatejobController(ICreatejobService createjobService)
        {
            this.createjobService = createjobService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/Createjob/GetJobData")]
        public JsonResult GetJobData()
        {
            try
            {
                var lsdata = createjobService.GetList();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                return Json("");
            }

        }

        [HttpPost]
        [Route("/Createjob/SaveJobData")]
        public JsonResponseModel SaveJobData(CreatejobRequest createjobRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                CreatejobModel model = new CreatejobModel();
                model.job_id = createjobRequest.JobId;
                model.jobtitle = createjobRequest.Title;
                model.jobposition = createjobRequest.Jobposition;
                model.qualification = createjobRequest.qualification;
                model.jobtype = createjobRequest.Jobtype;
                model.jobdescription = createjobRequest.Jobdescription;
                model.vacancies = createjobRequest.Vacancies;
                model.experience = createjobRequest.Experience;
                model.validupto = createjobRequest.Validupto;
                model.createddate = createjobRequest.Createddate;
                model.startsalary = createjobRequest.StartSalary;
                model.endsalary = createjobRequest.EndSalary;
                model.createdby = createjobRequest.Createdby;
                model.IsActive = createjobRequest.IsActive;

                // Call the service method to add or update the employee
                var result = createjobService.AddOrUpdate(model);
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
        [Route("/Createjob/DetailsModel")]
        public JsonResponseModel DetailsModel(long jobid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var createjob = createjobService.Get(jobid);
                if (createjob != null)
                {
                    // Populate QualificationRequest object
                    CreatejobRequest job = new CreatejobRequest();
                    job.JobId = createjob.job_id;
                    job.Jobdescription = createjob.jobdescription;

                    // Populate JsonResponseModel
                    objreturn.strMessage = "";
                    objreturn.isError = false;

                    objreturn.result = job;
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
        [Route("/Createjob/EditJobDetails")]
        public JsonResponseModel EditJobDetails(long jobid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var createjob = createjobService.Get(jobid);
                if (createjob != null)
                {
                    // Populate QualificationRequest object
                    CreatejobRequest job = new CreatejobRequest();
                    job.JobId = createjob.job_id;
                    job.Title = createjob.jobtitle;
                    job.Jobposition = createjob.jobposition;
                    job.qualification = createjob.qualification;
                    job.Jobtype = createjob.jobtype;
                    job.Jobdescription = createjob.jobdescription;
                    job.Vacancies = createjob.vacancies;
                    job.Experience = createjob.experience;
                    job.Validupto = createjob.validupto;
                    job.Createddate = createjob.createddate;
                    job.StartSalary = createjob.startsalary;
                    job.EndSalary = createjob.endsalary;
                    job.Createdby = createjob.createdby;
                    job.IsActive = createjob.IsActive;

                    // Populate JsonResponseModel
                    objreturn.strMessage = "";
                    objreturn.isError = false;

                    objreturn.result = job;
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
        [Route("/Createjob/DeleteJobData")]
        public JsonResponseModel DeleteJobData(long jobid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var createjobService = new CreatejobService(); // Instantiate your service or repository class
                objreturn = createjobService.Delete(jobid);
            }
            catch (Exception)
            {
                // Handle error
                return objreturn;
            }
            return objreturn;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;
namespace Recruitment.Controllers
{
    public class ListofCandidateController : Controller
    {
        private IListofCandidateService listofCandidateService;
        public ListofCandidateController(IListofCandidateService listofCandidateService)
        {
            this.listofCandidateService = listofCandidateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/ListofCandidate/GetListofCandidateData")]
        public JsonResult GetListofCandidateData()
        {
            try
            {
                var lsdata = listofCandidateService.GetList();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                return Json("");
            }

        }

        //[HttpPost]
        //[Route("/ApplicationForm/SaveApplicationFormData")]
        //public JsonResponseModel SaveApplicationFormData(ApplicationFormRequest applicationFormRequest)
        //{
        //    JsonResponseModel obj = new JsonResponseModel();
        //    try
        //    {
        //        ApplicationFormModel model = new ApplicationFormModel();
        //        // Check if an image file is uploaded
        //        if (applicationFormRequest.Candidate_image != null && applicationFormRequest.Candidate_image.Length > 0)
        //        {
        //            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(applicationFormRequest.Candidate_image.FileName);
        //            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CandidateImages", fileName);
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                applicationFormRequest.Candidate_image.CopyTo(stream);
        //            }
        //            model.candidate_image = "/CandidateImages/" + fileName;
        //        }


        //        // Check if an image file is uploaded
        //        if (applicationFormRequest.Resume_image != null && applicationFormRequest.Resume_image.Length > 0)
        //        {
        //            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(applicationFormRequest.Resume_image.FileName);
        //            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ResumeImages", fileName);
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                applicationFormRequest.Resume_image.CopyTo(stream);
        //            }
        //            model.resume_image = "/ResumeImages/" + fileName;
        //        }

        //        model.candidate_id = applicationFormRequest.Candidate_id;
        //        model.job_id = applicationFormRequest.Job_id;
        //        model.title = applicationFormRequest.Title;
        //        model.firstname = applicationFormRequest.FirstName;
        //        model.middlename = applicationFormRequest.MiddleName;
        //        model.lastname = applicationFormRequest.LastName;
        //        model.dateofbirth = applicationFormRequest.Dateofbirth;
        //        model.age = applicationFormRequest.Age;
        //        model.contactno = applicationFormRequest.Contactno;
        //        model.email = applicationFormRequest.Email;
        //        model.gender = applicationFormRequest.Gender;
        //        model.address = applicationFormRequest.Address;
        //        model.qualification = applicationFormRequest.qualification;
        //        model.experience = applicationFormRequest.Experience;
        //        model.result = applicationFormRequest.Result;
        //        model.IsActive = applicationFormRequest.IsActive;

        //        // Call the service method to add or update the employee
        //        var result = listofCandidateService.AddOrUpdate(model);
        //        obj.result = result.result;
        //        obj.Message = "Record saved successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle error
        //        obj.result = false;
        //        obj.Message = "An error occurred: " + ex.Message;
        //    }

        //    return obj;
        //}

        //[HttpPost]
        //[Route("/ApplicationForm/EditApplicationFormDetails")]
        //public JsonResponseModel EditApplicationFormDetails(long candidateid)
        //{
        //    JsonResponseModel objreturn = new JsonResponseModel();
        //    try
        //    {
        //        var application = listofCandidateService.Get(candidateid);
        //        if (application != null)
        //        {
        //            // Populate QualificationRequest object
        //            ApplicationFormRequest obj = new ApplicationFormRequest();
        //            obj.Candidate_id = application.candidate_id;
        //            obj.Job_id = application.job_id;
        //            obj.Title = application.title;
        //            obj.FirstName = application.firstname;
        //            obj.MiddleName = application.middlename;
        //            obj.LastName = application.lastname;
        //            obj.Dateofbirth = application.dateofbirth;
        //            obj.Age = application.age;
        //            obj.Contactno = application.contactno;
        //            obj.Email = application.email;
        //            obj.Gender = application.gender;
        //            obj.Address = application.address;
        //            obj.qualification = application.qualification;
        //            obj.Experience = application.experience;
        //            obj.Candidate_image = null;
        //            obj.Resume_image = null;
        //            obj.Result = application.result;
        //            obj.IsActive = application.IsActive;

        //            // Populate JsonResponseModel
        //            objreturn.strMessage = "";
        //            objreturn.isError = false;

        //            objreturn.result = obj;
        //        }
        //        else
        //        {
        //            objreturn.strMessage = "Enter Valid Id.";
        //            objreturn.isError = true;
        //            objreturn.type = PopupMessageType.error.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception
        //        ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);
        //        objreturn.strMessage = "An error occurred.";
        //        objreturn.isError = true;
        //        objreturn.type = PopupMessageType.error.ToString();
        //    }
        //    return objreturn;
        //}

        //[HttpPost]
        //[Route("/ApplicationForm/DeleteApplicationFormData")]
        //public JsonResponseModel DeleteApplicationFormData(long candidateid)
        //{
        //    JsonResponseModel objreturn = new JsonResponseModel();
        //    try
        //    {
        //        var applicationform = new ApplicationFormService(); // Instantiate your service or repository class
        //        objreturn = applicationform.Delete(candidateid);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle error
        //        return objreturn;
        //    }
        //    return objreturn;
        //}
    }
}

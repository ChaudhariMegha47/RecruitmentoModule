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

        [HttpPost]
        [Route("/ListofCandidate/SaveListofCandidateData")]
        public JsonResponseModel SaveListofCandidateData(ListofCandidateRequest listofCandidateRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                ListofCandidateModel model = new ListofCandidateModel();
                // Check if an image file is uploaded
                if (listofCandidateRequest.Candidate_image != null && listofCandidateRequest.Candidate_image.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(listofCandidateRequest.Candidate_image.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CandidateImages", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        listofCandidateRequest.Candidate_image.CopyTo(stream);
                    }
                    model.candidate_image = "/CandidateImages/" + fileName;
                }

                
                // Check if an image file is uploaded
                if (listofCandidateRequest.Resume_image != null && listofCandidateRequest.Resume_image.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(listofCandidateRequest.Resume_image.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ResumeImages", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        listofCandidateRequest.Resume_image.CopyTo(stream);
                    }
                    model.resume_image = "/ResumeImages/" + fileName;
                }

                model.candidate_id = listofCandidateRequest.Candidate_id;
                model.job_id = listofCandidateRequest.Job_id;
                model.title = listofCandidateRequest.Title;
                model.firstname = listofCandidateRequest.FirstName;
                model.middlename = listofCandidateRequest.MiddleName;
                model.lastname = listofCandidateRequest.LastName;
                model.dateofbirth = listofCandidateRequest.Dateofbirth;
                model.age = listofCandidateRequest.Age;
                model.contactno = listofCandidateRequest.Contactno;
                model.email = listofCandidateRequest.Email;
                model.gender = listofCandidateRequest.Gender;
                model.address = listofCandidateRequest.Address;
                model.qualification = listofCandidateRequest.qualification;
                model.experience = listofCandidateRequest.Experience;
                model.result = listofCandidateRequest.Result;
                model.IsActive = listofCandidateRequest.IsActive;

                // Call the service method to add or update the employee
                var result = listofCandidateService.AddOrUpdate(model);
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
        [Route("/ListofCandidate/EditListofCandidateDetails")]
        public JsonResponseModel EditListofCandidateDetails(long candidateid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var application = listofCandidateService.Get(candidateid);
                if (application != null)
                {
                    // Populate QualificationRequest object
                    ListofCandidateRequest obj = new ListofCandidateRequest();
                    obj.Candidate_id = application.candidate_id;
                    obj.Job_id = application.job_id;
                    obj.Title = application.title;
                    obj.FirstName = application.firstname;
                    obj.MiddleName = application.middlename;
                    obj.LastName = application.lastname;
                    obj.Dateofbirth = application.dateofbirth;
                    obj.Age = application.age;
                    obj.Contactno = application.contactno;
                    obj.Email = application.email;
                    obj.Gender = application.gender;
                    obj.Address = application.address;
                    obj.qualification = application.qualification;
                    obj.Experience = application.experience;
                    obj.Candidate_image = null;
                    obj.Resume_image = null;
                    obj.Result = application.result;
                    obj.IsActive = application.IsActive;

                    // Populate JsonResponseModel
                    objreturn.strMessage = "";
                    objreturn.isError = false;

                    objreturn.result = obj;
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
        [Route("/ListofCandidate/DeleteListofCandidateData")]
        public JsonResponseModel DeleteListofCandidateData(long candidateid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var applicationform = new ListofCandidateService(); // Instantiate your service or repository class
                objreturn = applicationform.Delete(candidateid);
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

﻿using Microsoft.AspNetCore.Mvc;
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
        private IListofCandidateService applicationform;
        public ListofCandidateController(IListofCandidateService applicationformservice)
        {
            this.applicationform = applicationformservice;
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
                var lsdata = applicationform.GetList();

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
        public JsonResponseModel SaveListofCandidateData(ListofCandidateRequest applicationformModel)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                ListofCandidateModel model = new ListofCandidateModel();
                // Check if an image file is uploaded
                if (applicationformModel.Candidate_image != null && applicationformModel.Candidate_image.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(applicationformModel.Candidate_image.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CandidateImages", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        applicationformModel.Candidate_image.CopyTo(stream);
                    }
                    model.candidate_image = "/CandidateImages/" + fileName;
                }

                
                // Check if an image file is uploaded
                if (applicationformModel.Resume_image != null && applicationformModel.Resume_image.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(applicationformModel.Resume_image.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ResumeImages", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        applicationformModel.Resume_image.CopyTo(stream);
                    }
                    model.resume_image = "/ResumeImages/" + fileName;
                }

                model.candidate_id = applicationformModel.Candidate_id;
                model.job_id = applicationformModel.Job_id;
                model.title = applicationformModel.Title;
                model.firstname = applicationformModel.FirstName;
                model.middlename = applicationformModel.MiddleName;
                model.lastname = applicationformModel.LastName;
                model.gender = applicationformModel.Gender;
                model.dateofbirth = applicationformModel.Dateofbirth;
                model.age = applicationformModel.Age;
                model.email = applicationformModel.Email;
                model.address = applicationformModel.Address;
                model.contactno = applicationformModel.Contactno;
                model.experience = applicationformModel.Experience;
                model.qualification = applicationformModel.qualification;
                model.result = applicationformModel.Result;
                model.IsActive = applicationformModel.IsActive;

                // Call the service method to add or update the employee
                var result = applicationform.AddOrUpdate(model);
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
                var application = applicationform.Get(candidateid);
                if (application != null)
                {
                    // Populate QualificationRequest object
                    ListofCandidateRequest obj = new ListofCandidateRequest();
                    obj.Candidate_id = application.candidate_id;
                    obj.Job_id = application.job_id;
                    obj.Candidate_image = null;
                    obj.Title = application.title;
                    obj.FirstName = application.firstname;
                    obj.MiddleName = application.middlename;
                    obj.LastName = application.lastname;
                    obj.Gender = application.gender;
                    obj.Dateofbirth = application.dateofbirth;
                    obj.Age = application.age;
                    obj.Email = application.email;
                    obj.Address = application.address;
                    obj.Contactno = application.contactno;
                    obj.Experience = application.experience;
                    obj.qualification = application.qualification;
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

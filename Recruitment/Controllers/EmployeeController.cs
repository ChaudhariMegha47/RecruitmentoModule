using Microsoft.AspNetCore.Mvc;
using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Model.Service;
using Recruitment.Model.System;
using Recruitment.Models.Entities;
using Recruitment.Services.Service;

namespace Recruitment.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/Employee/GetEmployeeData")]
        public JsonResult GetEmployeeData()
        {
            try
            {
                var lsdata = employeeService.GetList();

                return Json(new { recordsFiltered = lsdata.Count(), recordsTotal = lsdata.Count(), data = lsdata });
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex.Message, ex.ToString(), ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ControllerContext.HttpContext.Request.Method);

                return Json("");
            }
        }

        [HttpPost]
        [Route("/Employee/SaveEmployeeData")]
        public JsonResponseModel SaveEmployeeData(EmployeeRequest employeeRequest)
        {
            JsonResponseModel obj = new JsonResponseModel();
            try
            {
                EmployeeModel model = new EmployeeModel();
                // Check if an image file is uploaded
                if (employeeRequest.ImageFile != null && employeeRequest.ImageFile.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(employeeRequest.ImageFile.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "EmployeeImages", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        employeeRequest.ImageFile.CopyTo(stream);
                    }
                    model.Image_Path = "/EmployeeImages/" + fileName;
                }

                model.emp_id = employeeRequest.Emp_id;
                model.title = employeeRequest.Title;
                model.firstname = employeeRequest.Firstname;
                model.lastname = employeeRequest.Lastname;
                model.gender = employeeRequest.Gender;
                model.strdateofbirth = employeeRequest.Dateofbirth;
                model.email = employeeRequest.Email;
                model.contactno = employeeRequest.Contactno;
                model.designation = employeeRequest.Designation;
                model.IsActive = employeeRequest.IsActive;

                // Call the service method to add or update the employee
                var result = employeeService.AddOrUpdate(model);
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
        [Route("/Employee/EditEmployeeDetails")]
        public JsonResponseModel EditEmployeeDetails(long empid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var employee = employeeService.Get(empid);
                if (employee != null)
                {
                    // Populate QualificationRequest object
                    EmployeeRequest job = new EmployeeRequest();
                    job.Emp_id = employee.emp_id;
                    job.Title = employee.title;
                    job.Firstname = employee.firstname;
                    job.Lastname = employee.lastname;
                    job.Gender = employee.gender;
                    job.Dateofbirth = employee.strdateofbirth;
                    job.Email = employee.email;
                    job.Contactno = employee.contactno;
                    job.Designation = employee.designation;
                    job.ImageFile = null;
                    job.IsActive = employee.IsActive;

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
        [Route("/Employee/DeleteEmployeeData")]
        public JsonResponseModel DeleteEmployeeData(long empid)
        {
            JsonResponseModel objreturn = new JsonResponseModel();
            try
            {
                var employeeService = new EmployeeService(); // Instantiate your service or repository class
                objreturn = employeeService.Delete(empid);
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

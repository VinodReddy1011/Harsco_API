using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployee _empService;        

        public EmployeeController(IEmployee employeeRepository,IMapper mapper)
        {
            this._empService = employeeRepository;            
        }
        [HttpGet]
        public ActionResult<IEnumerable<GetEmployeeVm>> GetEmployeeDetails()
        {
            var details =   _empService.GetAllEmployeeDetails();
            if (details == null)
            {
                return Forbid("details are empty");
            }

            var mapRecords = _empService.GetAllEmployeeDetails();

            return Ok(mapRecords);
        }
        [HttpPost]
        [Route("CreateEmployeeDetails")]
        public async Task<ActionResult<bool>> CreateEmployeeDetails([FromBody]EmployeeVm employeeVm)
        {
            if (employeeVm == null)
            {
                return BadRequest("Employee form is null");
            }
            if (ModelState.IsValid)
            {
                var employeeDOBYear = employeeVm.Dob.Year;
                var currentYear = DateTime.Now.Year;
                if(currentYear-employeeDOBYear < 18)
                {
                    return BadRequest("Age must be greater than 18 years");
                }

                //Employee empDb = new Employee();
                //empDb.Package = employeeVm.Package;
                //empDb.FirstName = employeeVm.FirstName;
                //empDb.LastName = employeeVm.LastName;
                //empDb.Email = employeeVm.Email;
                //empDb.Education = employeeVm.Education;
                //empDb.Dob= employeeVm.Dob;
                //empDb.Experience= employeeVm.Experience;
                //empDb.Company= employeeVm.Company;
                //empDb.Gender= employeeVm.Gender;
                
                var createdForm =  _empService.CreateEmployeeForm(employeeVm);
                return Ok(createdForm);
            }
               
            
            return BadRequest("Request Not Valid");

           
        }


        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public async Task<ActionResult<bool>> UpdateEmployeeDetails(UpdateEmpVm updateVm)
        {

            if (updateVm.id == 0)
            {
                return BadRequest("Id is null");
            }
            var employeeDOBYear = updateVm.Dob.Year;
            var currentYear = DateTime.Now.Year;
            if (currentYear - employeeDOBYear < 18)
            {
                return BadRequest("Age must be greater than 18 years");
            }

            //Employee empDb = new Employee();
            //empDb.Package = updateVm.Package;
            //empDb.FirstName = updateVm.FirstName;
            //empDb.LastName = updateVm.LastName;
            //empDb.Email = updateVm.Email;
            //empDb.Education = updateVm.Education;
            //empDb.Dob = updateVm.Dob;
            //empDb.Experience = updateVm.Experience;
            //empDb.Company = updateVm.Company;
            //empDb.Gender = updateVm.Gender;

            var employee =  _empService.UpdateEmployeeDetails(updateVm.id, updateVm);
            if (employee == false)
            {
                return NotFound("Employee Not Updated");
            }

            return Ok(employee);

        }

        [HttpDelete]
        [Route("DeleteEmployeeDetails")]
        public async Task<ActionResult<bool>> DeleteEmployeeDetails(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is null");
            }

            var employee =  _empService.DeleteEmployeeDetails(id);
            if (employee == false)
            {
                return NotFound("Employee Not Updated");
            }

            return Ok(employee);
        }

        //[HttpGet]
        //[Route("GetEmployeeById")]
        //public async Task<ActionResult<GetEmployeeVm>> GetEmployeeById(int id)
        //{
        //    if (id == 0 || id <0)
        //    {
        //        return BadRequest("id is null");
        //    }
        //    var employee= _empService.GetEmployeeDetailsById(id);
        //    if (employee == null)
        //    {
        //        return NotFound("Employee not found");
        //    }

        //    return Ok(employee);
        //}


    }
}

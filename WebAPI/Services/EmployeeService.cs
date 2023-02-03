using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ModelBinding;
using WebAPI.Contracts;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class EmployeeService:IEmployee
    {
        private readonly EmployeeDbContext _edc;        

        public EmployeeService(EmployeeDbContext employeeDbContext,IMapper mapper)
        {
            this._edc = employeeDbContext;            
        }
        public List<Employee> GetAllEmployeeDetails()
        {
            return  _edc.Employees.ToList();

        }

        public Employee GetEmployeeDetailsById(int id)
        {
            return  _edc.Employees.Find(id);
            
        }

        public bool CreateEmployeeForm(EmployeeVm employeeVm)
        {
            Employee empDb = new Employee();
            empDb.Package = employeeVm.Package;
            empDb.FirstName = employeeVm.FirstName;
            empDb.LastName = employeeVm.LastName;
            empDb.Email = employeeVm.Email;
            empDb.Education = employeeVm.Education;
            empDb.Dob = employeeVm.Dob;
            empDb.Experience = employeeVm.Experience;
            empDb.Company = employeeVm.Company;
            empDb.Gender = employeeVm.Gender;

            var result =  _edc.Employees.Add(empDb);
             _edc.SaveChanges();
            return true;

        }

        public bool UpdateEmployeeDetails(int id, UpdateEmpVm employee)
        {
            var result =  _edc.Employees.Find(id);
            if (result == null)
            {
                return false;
            }

            result.Package = employee.Package;
            result.FirstName = employee.FirstName;
            result.LastName = employee.LastName;
            result.Email = employee.Email;
            result.Education = employee.Education;
            result.Dob = employee.Dob;
            result.Experience = employee.Experience;
            result.Company = employee.Company;
            result.Gender = employee.Gender;

            //_edc.Update<Employee>(employee);

             _edc.SaveChanges();
            return true;
        }


        public bool DeleteEmployeeDetails(int id)
        {
            var result =  _edc.Employees.Find(id);
            if (result == null)
            {
                return false;
            }
             _edc.Remove(result);
             _edc.SaveChanges();
            return true;

        }





        



        

        
    }
}

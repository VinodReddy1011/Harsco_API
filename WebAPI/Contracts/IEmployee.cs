using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Contracts
{
    public interface IEmployee
    {
        List<Employee> GetAllEmployeeDetails();

        Employee GetEmployeeDetailsById(int id);

        bool CreateEmployeeForm(EmployeeVm employee);

        bool UpdateEmployeeDetails(int id, UpdateEmpVm employee);

        bool DeleteEmployeeDetails(int id);
    }
}

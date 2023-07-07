using Service.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployee(EmployeeCreateDTO employeeDto);
        Task UpdateEmployee(int employeeId, EmployeeUpdateDTO employeeDto);
        Task DeleteEmployee(int employeeId);
        Task<EmployeeDTO> GetEmployeeById(int employeeId);
        Task<List<EmployeeDTO>> GetAllEmployees();
        Task<List<EmployeeDTO>> SearchEmployees(string searchTerm);
    }
}

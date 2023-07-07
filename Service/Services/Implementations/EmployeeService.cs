using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Employee;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task CreateEmployee(EmployeeCreateDTO employeeDto)
        {
            await _employeeRepository.CreateAsync(_mapper.Map<Employee>(employeeDto));
        }

        public async Task UpdateEmployee(int employeeId, EmployeeUpdateDTO employeeDto)
        {
            var employee = await _employeeRepository.FindAsync(employeeId);
            if (employee != null)
            {
                _mapper.Map(employeeDto, employee);
                await _employeeRepository.UpdateAsync(employee);
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await _employeeRepository.FindAsync(employeeId);
            if (employee != null)
            {
                await _employeeRepository.DeleteAsync(employee);
            }
        }

        public async Task<EmployeeDTO> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeRepository.FindAsync(employeeId);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _employeeRepository.FindAllAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<List<EmployeeDTO>> SearchEmployees(string searchTerm)
        {
            var employees = await _employeeRepository.FindAllAsync(e => e.FullName.Contains(searchTerm));
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }
    }
}

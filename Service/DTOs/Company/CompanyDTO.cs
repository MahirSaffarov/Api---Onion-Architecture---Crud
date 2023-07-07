using Service.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Company
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}

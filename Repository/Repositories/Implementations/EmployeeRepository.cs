using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementations
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Employee>> GetAllEmployeesByCompanyId(int companyId)
        {
            return await _entities.Where(e => e.CompanyId == companyId).ToListAsync();
        }
    }
}

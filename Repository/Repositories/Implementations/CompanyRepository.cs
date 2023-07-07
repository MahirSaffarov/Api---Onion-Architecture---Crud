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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Company>> GetAllCompaniesWithEmployees()
        {
            return await _entities.Include(c => c.Employees).ToListAsync();
        }

        public async Task<Company> GetCompanyWithEmployees(int companyId)
        {
            return await _entities.Include(c => c.Employees).FirstOrDefaultAsync(c => c.Id == companyId);
        }
    }

}

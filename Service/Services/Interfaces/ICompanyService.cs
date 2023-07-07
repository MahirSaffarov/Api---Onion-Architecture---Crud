using Service.DTOs.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICompanyService
    {
        Task CreateCompany(CompanyCreateDTO companyDto);
        Task UpdateCompany(int companyId, CompanyUpdateDTO companyDto);
        Task DeleteCompany(int companyId);
        Task<CompanyDTO> GetCompanyById(int companyId);
        Task<List<CompanyDTO>> GetAllCompanies();
        Task<List<CompanyDTO>> SearchCompanies(string searchTerm);
    }
}

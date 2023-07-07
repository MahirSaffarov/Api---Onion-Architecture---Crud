using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Company;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task CreateCompany(CompanyCreateDTO companyDto)
        {
            await _companyRepository.CreateAsync(_mapper.Map<Company>(companyDto));
        }

        public async Task UpdateCompany(int companyId, CompanyUpdateDTO companyDto)
        {
            var company = await _companyRepository.FindAsync(companyId);
            if (company != null)
            {
                _mapper.Map(companyDto, company);
                await _companyRepository.UpdateAsync(company);
            }
        }

        public async Task DeleteCompany(int companyId)
        {
            var company = await _companyRepository.FindAsync(companyId);
            if (company != null)
            {
                await _companyRepository.DeleteAsync(company);
            }
        }

        public async Task<CompanyDTO> GetCompanyById(int companyId)
        {
            var company = await _companyRepository.FindAsync(companyId);
            return _mapper.Map<CompanyDTO>(company);
        }

        public async Task<List<CompanyDTO>> GetAllCompanies()
        {
            var companies = await _companyRepository.FindAllAsync();
            return _mapper.Map<List<CompanyDTO>>(companies);
        }

        public async Task<List<CompanyDTO>> SearchCompanies(string searchTerm)
        {
            var companies = await _companyRepository.FindAllAsync(c => c.Name.Contains(searchTerm));
            return _mapper.Map<List<CompanyDTO>>(companies);
        }
    }
}

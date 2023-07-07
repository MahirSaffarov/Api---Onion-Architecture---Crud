using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Company;
using Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody]CompanyCreateDTO companyDto)
        {
            await _companyService.CreateCompany(companyDto);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany([FromRoute] int id, [FromBody] CompanyUpdateDTO companyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _companyService.UpdateCompany(id, companyDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteCompany(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCompanies([FromQuery] string searchTerm)
        {
            var companies = await _companyService.SearchCompanies(searchTerm);
            return Ok(companies);
        }
    }
}

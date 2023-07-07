using AutoMapper;
using Domain.Entities;
using Service.DTOs.Employee;
using Service.DTOs.Company;
using System.Diagnostics.Metrics;

namespace API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<Company, CompanyDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<CompanyUpdateDTO, Company>();

            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<EmployeeUpdateDTO, Employee>();
        }
    }
}

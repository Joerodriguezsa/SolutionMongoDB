using AutoMapper;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using MongoDB.Bson;

namespace Annarth.Infrastructure.Profiles
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {        

            // Mapping for Employee
            CreateMap<Employee, EmployeeConsultarDTO>().ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));
            CreateMap<EmployeeCrearDTO, Employee>().ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => ObjectId.Parse(src.CompanyId)));
            CreateMap<EmployeeActulizarDTO, Employee>();
            CreateMap<EmployeeFiltrarDTO, Employee>();

            // Mapping for Company
            CreateMap<Company, CompanyConsultarDTO>();
            CreateMap<CompanyCrearDTO, Company>();
            CreateMap<CompanyActualizarDTO, Company>();
        }
    }
}

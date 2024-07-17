using AutoMapper;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;

namespace Annarth.Infrastructure.Profiles
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {          
            CreateMap<Employee, EmployeeConsultarDTO>().ReverseMap();
            CreateMap<EmployeeCrearDTO, Employee>();
            CreateMap<EmployeeActulizarDTO, Employee>();
            CreateMap<EmployeeFiltrarDTO, Employee>();
        }
    }
}

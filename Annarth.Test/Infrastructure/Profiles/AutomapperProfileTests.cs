using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using Annarth.Infrastructure.Profiles;
using AutoMapper;
using MongoDB.Bson;

namespace Annarth.Test.Infrastructure.Profiles
{
    public class AutomapperProfileTests
    {
        private readonly IMapper _mapper;

        public AutomapperProfileTests()
        {
            // Configuración de AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });
            _mapper = mapperConfig.CreateMapper();
        }
                
        [Fact]
        public void AutoMapper_Map_Employee_To_EmployeeConsultarDTO()
        {
            // Arrange
            var companyId = ObjectId.GenerateNewId();
            var employee = new Employee
            {
                Id = ObjectId.GenerateNewId(),
                CreatedOn = DateTime.UtcNow,
                Email = "employee@example.com",
                Name = "John Doe",
                CompanyId = companyId,
                Company = new Company { Id = companyId, CompanyName = "ACME Inc.", State = true }
            };

            // Act
            var employeeDTO = _mapper.Map<EmployeeConsultarDTO>(employee);

            // Assert
            Assert.Equal(employee.Id.ToString(), employeeDTO.Id);
            Assert.Equal(employee.CreatedOn, employeeDTO.CreatedOn);
            Assert.Equal(employee.Email, employeeDTO.Email);
            Assert.Equal(employee.Name, employeeDTO.Name);
            Assert.Equal(employee.Company.Id.ToString(), employeeDTO.Company.Id);
            Assert.Equal(employee.Company.CompanyName, employeeDTO.Company.CompanyName);
            Assert.Equal(employee.Company.State, employeeDTO.Company.State);
        }

        [Fact]
        public void AutoMapper_Map_EmployeeCrearDTO_To_Employee()
        {
            // Arrange
            var companyId = ObjectId.GenerateNewId().ToString();
            var employeeCrearDTO = new EmployeeCrearDTO
            {
                CompanyId = companyId,
                CreatedOn = DateTime.UtcNow,
                Email = "newemployee@example.com",
                Name = "Jane Doe",
                PortalId = 1,
                RoleId = 2,
                StatusId = 1,
                Username = "jane.doe"
            };

            // Act
            var employee = _mapper.Map<Employee>(employeeCrearDTO);

            // Assert
            Assert.Equal(ObjectId.Parse(companyId), employee.CompanyId);
            Assert.Equal(employeeCrearDTO.CreatedOn, employee.CreatedOn);
            Assert.Equal(employeeCrearDTO.Email, employee.Email);
            Assert.Equal(employeeCrearDTO.Name, employee.Name);
            Assert.Equal(employeeCrearDTO.PortalId, employee.PortalId);
            Assert.Equal(employeeCrearDTO.RoleId, employee.RoleId);
            Assert.Equal(employeeCrearDTO.StatusId, employee.StatusId);
            Assert.Equal(employeeCrearDTO.Username, employee.Username);
        }

        [Fact]
        public void AutoMapper_Map_EmployeeActulizarDTO_To_Employee()
        {
            // Arrange
            var employeeActualizarDTO = new EmployeeActulizarDTO
            {
                CompanyId = ObjectId.GenerateNewId().ToString(),
                CreatedOn = DateTime.UtcNow,
                Email = "updatedemployee@example.com",
                Name = "Updated John Doe",
                PortalId = 2,
                RoleId = 1,
                StatusId = 2,
                Username = "john.doe"
            };
            var employee = new Employee
            {
                Id = ObjectId.GenerateNewId(),
                CreatedOn = DateTime.UtcNow.AddDays(-1),
                Email = "employee@example.com",
                Name = "John Doe",
                CompanyId = ObjectId.GenerateNewId(),
                PortalId = 1,
                RoleId = 2,
                StatusId = 1,
                Username = "johndoe"
            };

            // Act
            var updatedEmployee = _mapper.Map(employeeActualizarDTO, employee);

            // Assert
            Assert.Equal(employeeActualizarDTO.CompanyId, updatedEmployee.CompanyId.ToString());
            Assert.Equal(employeeActualizarDTO.CreatedOn, updatedEmployee.CreatedOn);
            Assert.Equal(employeeActualizarDTO.Email, updatedEmployee.Email);
            Assert.Equal(employeeActualizarDTO.Name, updatedEmployee.Name);
            Assert.Equal(employeeActualizarDTO.PortalId, updatedEmployee.PortalId);
            Assert.Equal(employeeActualizarDTO.RoleId, updatedEmployee.RoleId);
            Assert.Equal(employeeActualizarDTO.StatusId, updatedEmployee.StatusId);
            Assert.Equal(employeeActualizarDTO.Username, updatedEmployee.Username);
        }

        [Fact]
        public void AutoMapper_Map_EmployeeFiltrarDTO_To_Employee()
        {
            // Arrange
            var filtro = new EmployeeFiltrarDTO
            {                
                CompanyName = "ACME Inc.",
                Email = "employee@example.com",
                Name = "John Doe",
                Username = "johndoe",
                RoleId = 2,
                StatusId = 1,
                Telephone = "123-456-7890"
            };

            // Act
            var employee = _mapper.Map<Employee>(filtro);

            // Assert
            Assert.Equal(filtro.Name, employee.Name);
            Assert.Equal(filtro.Username, employee.Username);
            Assert.Equal(filtro.RoleId, employee.RoleId);
            Assert.Equal(filtro.StatusId, employee.StatusId);
            Assert.Equal(filtro.Telephone, employee.Telephone);
        }

        [Fact]
        public void AutoMapper_Map_Company_To_CompanyConsultarDTO()
        {
            // Arrange
            var company = new Company
            {
                Id = ObjectId.GenerateNewId(),
                CompanyName = "ACME Inc.",
                State = true
            };

            // Act
            var companyDTO = _mapper.Map<CompanyConsultarDTO>(company);

            // Assert
            Assert.Equal(company.Id.ToString(), companyDTO.Id);
            Assert.Equal(company.CompanyName, companyDTO.CompanyName);
            Assert.Equal(company.State, companyDTO.State);
        }

        [Fact]
        public void AutoMapper_Map_CompanyCrearDTO_To_Company()
        {
            // Arrange
            var companyCrearDTO = new CompanyCrearDTO
            {
                CompanyName = "New Company",
                State = true
            };

            // Act
            var company = _mapper.Map<Company>(companyCrearDTO);

            // Assert
            Assert.Equal(companyCrearDTO.CompanyName, company.CompanyName);
            Assert.Equal(companyCrearDTO.State, company.State);
            // Assert other properties as needed
        }

        [Fact]
        public void AutoMapper_Map_CompanyActualizarDTO_To_Company()
        {
            // Arrange
            var companyActualizarDTO = new CompanyActualizarDTO
            {
                CompanyName = "Updated Company",
                State = false
            };
            var company = new Company
            {
                Id = ObjectId.GenerateNewId(),
                CompanyName = "Old Company",
                State = true
            };

            // Act
            var updatedCompany = _mapper.Map(companyActualizarDTO, company);

            // Assert
            Assert.Equal(company.Id, updatedCompany.Id);
            Assert.Equal(companyActualizarDTO.CompanyName, updatedCompany.CompanyName);
            Assert.Equal(companyActualizarDTO.State, updatedCompany.State);
            // Assert other properties as needed
        }
    }
}

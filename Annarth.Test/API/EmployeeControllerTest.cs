using Annarth.API.Controllers;
using Annarth.Application.Interface.IService;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;

namespace Annarth.Test.API
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeService> _mockEmployeeService;
        private readonly IMapper _mapper;

        public EmployeeControllerTest()
        {
            _mockEmployeeService = new Mock<IEmployeeService>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new YourAutoMapperProfile()); // Reemplaza con tu configuración real de AutoMapper
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task GetById_ReturnsEmployee_WhenValidIdProvided()
        {
            // Arrange
            var employeeId = ObjectId.GenerateNewId();
            var expectedEmployee = new Employee { Id = employeeId, Name = "Test Employee" };
            _mockEmployeeService.Setup(repo => repo.GetByIdAsync(employeeId)).ReturnsAsync(expectedEmployee);

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.GetById(employeeId.ToString());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var employeeDTO = Assert.IsType<EmployeeConsultarDTO>(okResult.Value);
            Assert.Equal(expectedEmployee.Id.ToString(), employeeDTO.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenInvalidIdProvided()
        {
            // Arrange
            var invalidId = ObjectId.GenerateNewId().ToString();

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.GetById(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedEmployee_WhenValidEmployeeDTOProvided()
        {
            // Arrange
            var employeeDTO = new EmployeeCrearDTO { Name = "Test Employee" };
            var createdEmployeeId = ObjectId.GenerateNewId();
            var createdEmployee = new Employee { Id = createdEmployeeId, Name = "Test Employee" };
            _mockEmployeeService.Setup(repo => repo.CreateAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.Create(employeeDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var employeeConsultarDTO = Assert.IsType<EmployeeConsultarDTO>(createdAtActionResult.Value);
            Assert.Equal(createdEmployee.Id.ToString(), createdEmployeeId.ToString());
        }

        [Fact]
        public async Task Update_ReturnsUpdatedEmployee_WhenValidIdAndEmployeeDTOProvided()
        {
            // Arrange
            var employeeId = ObjectId.GenerateNewId();
            var employeeDTO = new EmployeeActulizarDTO { Name = "Updated Employee" };
            var existingEmployee = new Employee { Id = employeeId, Name = "Original Employee" };
            var updatedEmployee = new Employee { Id = employeeId, Name = "Updated Employee" };
            _mockEmployeeService.Setup(repo => repo.GetByIdAsync(employeeId)).ReturnsAsync(existingEmployee);
            _mockEmployeeService.Setup(repo => repo.UpdateAsync(It.IsAny<Employee>())).ReturnsAsync(updatedEmployee);

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.Update(employeeId.ToString(), employeeDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var employeeConsultarDTO = Assert.IsType<EmployeeConsultarDTO>(okResult.Value);
            Assert.Equal(updatedEmployee.Id.ToString(), employeeConsultarDTO.Id);
            Assert.Equal(updatedEmployee.Name, employeeConsultarDTO.Name);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenInvalidIdProvided()
        {
            // Arrange
            var invalidId = ObjectId.GenerateNewId().ToString();
            var employeeDTO = new EmployeeActulizarDTO { Name = "Updated Employee" };

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.Update(invalidId, employeeDTO);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenValidIdProvided()
        {
            // Arrange
            var employeeId = ObjectId.GenerateNewId();
            _mockEmployeeService.Setup(repo => repo.DeleteAsync(employeeId)).ReturnsAsync(true);

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.Delete(employeeId.ToString());

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenInvalidIdProvided()
        {
            // Arrange
            var invalidId = ObjectId.GenerateNewId();

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.Delete(invalidId.ToString());

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Id = ObjectId.GenerateNewId(), Name = "Employee 1" },
                new Employee { Id = ObjectId.GenerateNewId(), Name = "Employee 2" }
            };
            _mockEmployeeService.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var employeeConsultarDTOs = Assert.IsAssignableFrom<List<EmployeeConsultarDTO>>(okResult.Value);
            Assert.Equal(employees.Count, employeeConsultarDTOs.Count);
        }

        [Fact]
        public async Task GetFiltered_ReturnsFilteredEmployees_WhenCriteriaProvided()
        {
            // Arrange
            var filterCriteria = new EmployeeFiltrarDTO { Name = "Employee" };
            var filteredEmployees = new List<Employee>
            {
                new Employee { Id = ObjectId.GenerateNewId(), Name = "Employee 1" },
                new Employee { Id = ObjectId.GenerateNewId(), Name = "Employee 2" }
            };
            _mockEmployeeService.Setup(repo => repo.GetFilteredAsync(filterCriteria)).ReturnsAsync(filteredEmployees);

            var controller = new EmployeeController(_mockEmployeeService.Object, _mapper);

            // Act
            var result = await controller.GetFiltered(filterCriteria);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var employeeConsultarDTOs = Assert.IsAssignableFrom<List<EmployeeConsultarDTO>>(okResult.Value);
            Assert.Equal(filteredEmployees.Count, employeeConsultarDTOs.Count);
        }

        // Agregar más pruebas unitarias según sea necesario para cubrir más casos de borde y escenarios.

        private class YourAutoMapperProfile : Profile
        {
            public YourAutoMapperProfile()
            {
                CreateMap<EmployeeCrearDTO, Employee>();
                CreateMap<EmployeeActulizarDTO, Employee>();
                CreateMap<Employee, EmployeeConsultarDTO>();
                // Agregar más mapeos según sea necesario
            }
        }
    }
}

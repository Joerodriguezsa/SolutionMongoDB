using Annarth.Application.Interface.IRepository;
using Annarth.Application.Service;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using MongoDB.Bson;
using Moq;

namespace Annarth.Test.Application.Service
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Employee_When_Exists()
        {
            // Arrange
            var employeeId = ObjectId.GenerateNewId();
            var expectedEmployee = new Employee { Id = employeeId, Name = "Test Employee", Email = "test@example.com" };

            _mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(employeeId))
                                   .ReturnsAsync(expectedEmployee);

            // Act
            var result = await _employeeService.GetByIdAsync(employeeId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEmployee.Id, result.Id);
            Assert.Equal(expectedEmployee.Name, result.Name);
            Assert.Equal(expectedEmployee.Email, result.Email);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Employees()
        {
            // Arrange
            var expectedEmployees = new List<Employee>
            {
                new Employee { Id = ObjectId.GenerateNewId(), Name = "Employee 1", Email = "employee1@example.com" },
                new Employee { Id = ObjectId.GenerateNewId(), Name = "Employee 2", Email = "employee2@example.com" }
                // Añade más empleados según sea necesario para tus pruebas
            };

            _mockEmployeeRepository.Setup(repo => repo.GetAllAsync())
                                   .ReturnsAsync(expectedEmployees);

            // Act
            var result = await _employeeService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEmployees.Count, result.Count);
            // Puedes agregar más aserciones para verificar los datos de cada empleado si es necesario
        }

        [Fact]
        public async Task CreateAsync_Should_Create_New_Employee()
        {
            // Arrange
            var newEmployee = new Employee { Name = "New Employee", Email = "newemployee@example.com" };

            _mockEmployeeRepository.Setup(repo => repo.CreateAsync(newEmployee))
                                   .Returns(Task.CompletedTask); // Simula que la operación de creación se completa correctamente

            // Act
            await _employeeService.CreateAsync(newEmployee);

            // Assert
            _mockEmployeeRepository.Verify(repo => repo.CreateAsync(newEmployee), Times.Once);
            // Puedes agregar más aserciones si necesitas verificar más detalles de la operación de creación
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Employee()
        {
            // Arrange
            var updatedEmployee = new Employee { Id = ObjectId.GenerateNewId(), Name = "Updated Employee", Email = "updated@example.com" };

            _mockEmployeeRepository.Setup(repo => repo.UpdateAsync(updatedEmployee))
                                   .ReturnsAsync(updatedEmployee); // Simula que la operación de actualización se completa correctamente

            // Act
            var result = await _employeeService.UpdateAsync(updatedEmployee);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedEmployee.Id, result.Id);
            Assert.Equal(updatedEmployee.Name, result.Name);
            Assert.Equal(updatedEmployee.Email, result.Email);
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_Employee()
        {
            // Arrange
            var employeeId = ObjectId.GenerateNewId();

            _mockEmployeeRepository.Setup(repo => repo.DeleteAsync(employeeId))
                                   .ReturnsAsync(true); // Simula que la operación de eliminación se completa correctamente

            // Act
            var result = await _employeeService.DeleteAsync(employeeId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetFilteredAsync_Should_Return_Filtered_Employees()
        {
            // Arrange
            var filterDto = new EmployeeFiltrarDTO
            {
                Name = "John Doe",
                Email = "john@example.com"
                // Agrega más criterios de filtro según sea necesario para tus pruebas
            };

            var expectedEmployees = new List<Employee>
            {
                new Employee { Id = ObjectId.GenerateNewId(), Name = "John Doe", Email = "john@example.com" },
                // Añade más empleados que coincidan con los criterios de filtro
            };

            _mockEmployeeRepository.Setup(repo => repo.GetFilteredAsync(filterDto))
                                   .ReturnsAsync(expectedEmployees);

            // Act
            var result = await _employeeService.GetFilteredAsync(filterDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEmployees.Count, result.Count);
            // Puedes agregar más aserciones si necesitas verificar más detalles de los resultados filtrados
        }
    }
}

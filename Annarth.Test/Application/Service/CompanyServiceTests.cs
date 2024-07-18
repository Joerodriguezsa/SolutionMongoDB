using Annarth.Application.Interface.IRepository;
using Annarth.Application.Service;
using Annarth.Domain.Entities;
using MongoDB.Bson;
using Moq;

namespace Annarth.Test.Application.Service
{
    public class CompanyServiceTests
    {
        private readonly Mock<ICompanyRepository> _mockCompanyRepository;
        private readonly CompanyService _companyService;

        public CompanyServiceTests()
        {
            _mockCompanyRepository = new Mock<ICompanyRepository>();
            _companyService = new CompanyService(_mockCompanyRepository.Object);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Company_When_Exists()
        {
            // Arrange
            var companyId = ObjectId.GenerateNewId().ToString(); // Asegúrate de tener un ID válido existente en tus datos de prueba
            var expectedCompany = new Company { Id = ObjectId.GenerateNewId(), CompanyName = "Test Company", State = true };

            _mockCompanyRepository.Setup(repo => repo.GetByIdAsync(companyId))
                                  .ReturnsAsync(expectedCompany);

            // Act
            var result = await _companyService.GetByIdAsync(companyId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCompany.Id, result.Id);
            Assert.Equal(expectedCompany.CompanyName, result.CompanyName);
            Assert.Equal(expectedCompany.State, result.State);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Companies()
        {
            // Arrange
            var expectedCompanies = new List<Company>
            {
                new Company { Id = ObjectId.GenerateNewId(), CompanyName = "Company 1", State = true },
                new Company { Id = ObjectId.GenerateNewId(), CompanyName = "Company 2", State = false }
                // Añade más empresas según sea necesario para tus pruebas
            };

            _mockCompanyRepository.Setup(repo => repo.GetAllAsync())
                                  .ReturnsAsync(expectedCompanies);

            // Act
            var result = await _companyService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCompanies.Count, result.Count);
            // Puedes agregar más aserciones para verificar los datos de cada empresa si es necesario
        }

        [Fact]
        public async Task CreateAsync_Should_Create_New_Company()
        {
            // Arrange
            var newCompany = new Company { CompanyName = "New Company", State = true };

            _mockCompanyRepository.Setup(repo => repo.CreateAsync(newCompany))
                                  .Returns(Task.CompletedTask); // Simula que la operación de creación se completa correctamente

            // Act
            await _companyService.CreateAsync(newCompany);

            // Assert
            _mockCompanyRepository.Verify(repo => repo.CreateAsync(newCompany), Times.Once);
            // Puedes agregar más aserciones si necesitas verificar más detalles de la operación de creación
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Company()
        {
            // Arrange
            var companyId = ObjectId.GenerateNewId().ToString(); // ID de una empresa existente
            var updatedCompany = new Company { Id = ObjectId.GenerateNewId(), CompanyName = "Updated Company", State = true };

            _mockCompanyRepository.Setup(repo => repo.UpdateAsync(companyId, updatedCompany))
                                  .ReturnsAsync(updatedCompany); // Simula que la operación de actualización se completa correctamente

            // Act
            var result = await _companyService.UpdateAsync(companyId, updatedCompany);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedCompany.Id, result.Id);
            Assert.Equal(updatedCompany.CompanyName, result.CompanyName);
            Assert.Equal(updatedCompany.State, result.State);
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_Company()
        {
            // Arrange
            var companyId = "validCompanyId"; // ID de una empresa existente

            _mockCompanyRepository.Setup(repo => repo.DeleteAsync(companyId))
                                  .ReturnsAsync(true); // Simula que la operación de eliminación se completa correctamente

            // Act
            var result = await _companyService.DeleteAsync(companyId);

            // Assert
            Assert.True(result);
        }

        //[Fact]
        //public async Task FilterAsync_Should_Return_Filtered_Companies()
        //{
        //    // Arrange
        //    var filterDto = new CompanyFiltrarDTO
        //    {
        //        CompanyName = "Test Company",
        //        State = true
        //        // Agrega más criterios de filtro según sea necesario para tus pruebas
        //    };

        //    var expectedCompanies = new List<Company>
        //    {
        //        new Company { Id = ObjectId.GenerateNewId(), CompanyName = "Test Company", State = true },
        //        // Añade más empresas que coincidan con los criterios de filtro
        //    };

        //    _mockCompanyRepository.Setup(repo => repo.FilterAsync(filterDto))
        //                          .ReturnsAsync(expectedCompanies);

        //    // Act
        //    var result = await _companyService.FilterAsync(filterDto);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(expectedCompanies.Count, result.Count);
        //    // Puedes agregar más aserciones si necesitas verificar más detalles de los resultados filtrados
        //}
    }
}

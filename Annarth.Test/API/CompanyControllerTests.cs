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
    public class CompanyControllerTests
    {
        private readonly Mock<ICompanyService> _mockCompanyService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CompanyController _controller;

        public CompanyControllerTests()
        {
            _mockCompanyService = new Mock<ICompanyService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CompanyController(_mockCompanyService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Create_ValidCompany_ReturnsCreatedAtAction()
        {
            // Arrange
            var companyCrearDTO = new CompanyCrearDTO { CompanyName = "Test Company", State = true };
            var company = new Company { Id = ObjectId.GenerateNewId(), CompanyName = companyCrearDTO.CompanyName, State = companyCrearDTO.State };
            var companyConsultarDTO = new CompanyConsultarDTO { Id = company.Id.ToString(), CompanyName = company.CompanyName, State = company.State };

            _mockMapper.Setup(m => m.Map<Company>(companyCrearDTO)).Returns(company);
            _mockMapper.Setup(m => m.Map<CompanyConsultarDTO>(company)).Returns(companyConsultarDTO);
            _mockCompanyService.Setup(repo => repo.CreateAsync(company));

            // Act
            var result = await _controller.Create(companyCrearDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<CompanyConsultarDTO>(createdAtActionResult.Value);
            Assert.Equal(companyConsultarDTO.Id, returnValue.Id);
            Assert.Equal(companyConsultarDTO.CompanyName, returnValue.CompanyName);
            Assert.Equal(companyConsultarDTO.State, returnValue.State);
        }

        [Fact]
        public async Task Update_ExistingCompany_ReturnsOk()
        {
            // Arrange
            var companyId = ObjectId.GenerateNewId().ToString();
            var companyActualizarDTO = new CompanyActualizarDTO { CompanyName = "Updated Company", State = false };
            var company = new Company { Id = ObjectId.GenerateNewId(), CompanyName = "Original Company", State = true };
            var updatedCompany = new Company { Id = ObjectId.GenerateNewId(), CompanyName = companyActualizarDTO.CompanyName, State = companyActualizarDTO.State };
            var companyConsultarDTO = new CompanyConsultarDTO { Id = companyId, CompanyName = updatedCompany.CompanyName, State = updatedCompany.State };

            _mockCompanyService.Setup(repo => repo.GetByIdAsync(companyId)).ReturnsAsync(company);
            _mockMapper.Setup(m => m.Map(companyActualizarDTO, company)).Returns(updatedCompany);
            _mockCompanyService.Setup(repo => repo.UpdateAsync(companyId, updatedCompany)).ReturnsAsync(updatedCompany);
            _mockMapper.Setup(m => m.Map<CompanyConsultarDTO>(updatedCompany)).Returns(companyConsultarDTO);

            // Act
            var result = await _controller.Update(companyId, companyActualizarDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(companyConsultarDTO.Id, companyId);
            Assert.Equal(companyConsultarDTO.CompanyName, "Updated Company");
            Assert.Equal(companyConsultarDTO.State, false);
        }

        [Fact]
        public async Task Delete_ExistingCompany_ReturnsNoContent()
        {
            // Arrange
            var companyId = ObjectId.GenerateNewId().ToString();

            _mockCompanyService.Setup(repo => repo.DeleteAsync(companyId)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(companyId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetById_ExistingCompany_ReturnsOk()
        {
            // Arrange
            var companyId = ObjectId.GenerateNewId().ToString();
            var company = new Company { Id = ObjectId.Parse(companyId), CompanyName = "Test Company", State = true };
            var companyConsultarDTO = new CompanyConsultarDTO { Id = companyId, CompanyName = company.CompanyName, State = company.State };

            _mockCompanyService.Setup(repo => repo.GetByIdAsync(companyId)).ReturnsAsync(company);
            _mockMapper.Setup(m => m.Map<CompanyConsultarDTO>(company)).Returns(companyConsultarDTO);

            // Act
            var result = await _controller.GetById(companyId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<CompanyConsultarDTO>(okResult.Value);
            Assert.Equal(companyConsultarDTO.Id, returnValue.Id);
            Assert.Equal(companyConsultarDTO.CompanyName, returnValue.CompanyName);
            Assert.Equal(companyConsultarDTO.State, returnValue.State);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            // Arrange
            var companies = new List<Company>
            {
                new Company { Id = ObjectId.GenerateNewId(), CompanyName = "Company 1", State = true },
                new Company { Id = ObjectId.GenerateNewId(), CompanyName = "Company 2", State = false }
                // Añade más compañías según sea necesario para tus pruebas
            };

            var companyConsultarDTOs = new List<CompanyConsultarDTO>
            {
                new CompanyConsultarDTO { Id = companies[0].Id.ToString(), CompanyName = companies[0].CompanyName, State = companies[0].State },
                new CompanyConsultarDTO { Id = companies[1].Id.ToString(), CompanyName = companies[1].CompanyName, State = companies[1].State }
                // Añade más DTOs de compañías según sea necesario para tus pruebas
            };

            _mockCompanyService.Setup(repo => repo.GetAllAsync()).ReturnsAsync(companies);
            _mockMapper.Setup(m => m.Map<List<CompanyConsultarDTO>>(companies)).Returns(companyConsultarDTOs);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<CompanyConsultarDTO>>(okResult.Value);
            Assert.Equal(companyConsultarDTOs.Count, returnValue.Count);
            // Puedes agregar más aserciones para verificar los datos de cada DTO de compañía si es necesario
        }
    }
}

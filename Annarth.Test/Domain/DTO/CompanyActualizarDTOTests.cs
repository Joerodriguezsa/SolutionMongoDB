using Annarth.Domain.DTO;
using FluentValidation.TestHelper;

namespace Annarth.Test.Domain.DTO
{
    public class CompanyActualizarDTOTests
    {
        private readonly CompanyActualizarDTOValidator _validator;

        public CompanyActualizarDTOTests()
        {
            _validator = new CompanyActualizarDTOValidator();
        }

        [Fact]
        public void Should_Have_Error_When_CompanyName_Is_Null()
        {
            // Arrange
            var dto = new CompanyActualizarDTO { CompanyName = null };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CompanyName)
                  .WithErrorMessage("El nombre de la compañía es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_CompanyName_Is_Empty()
        {
            // Arrange
            var dto = new CompanyActualizarDTO { CompanyName = string.Empty };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CompanyName)
                  .WithErrorMessage("El nombre de la compañía es requerido");
        }

        [Fact]
        public void Should_Not_Have_Error_When_CompanyName_Is_Provided()
        {
            // Arrange
            var dto = new CompanyActualizarDTO { CompanyName = "Test Company" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CompanyName);
        }

        [Fact]
        public void Should_Set_And_Get_CompanyName()
        {
            // Arrange
            var dto = new CompanyActualizarDTO();
            var companyName = "Test Company";

            // Act
            dto.CompanyName = companyName;

            // Assert
            Assert.Equal(companyName, dto.CompanyName);
        }

        [Fact]
        public void Should_Set_And_Get_State()
        {
            // Arrange
            var dto = new CompanyActualizarDTO();
            var state = true;

            // Act
            dto.State = state;

            // Assert
            Assert.Equal(state, dto.State);
        }
    }
}

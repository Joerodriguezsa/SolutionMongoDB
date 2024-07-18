using Annarth.Domain.DTO;
using FluentValidation.TestHelper;

namespace Annarth.Test.Domain.DTO
{
    public class EmployeeCrearDTOTests
    {
        private readonly EmployeeCrearDTOValidator _validator;

        public EmployeeCrearDTOTests()
        {
            _validator = new EmployeeCrearDTOValidator();
        }

        [Fact]
        public void Should_Have_Error_When_CompanyId_Is_Empty()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { CompanyId = string.Empty };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CompanyId)
                  .WithErrorMessage("Campo CompanyId es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_CreatedOn_Is_Default()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { CreatedOn = default };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CreatedOn)
                  .WithErrorMessage("Campo CreatedOn es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { Email = string.Empty };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("Campo Email es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { Name = string.Empty };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorMessage("Campo Name es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { Password = string.Empty };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Password)
                  .WithErrorMessage("Campo Password es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_PortalId_Is_Default()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { PortalId = default };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.PortalId)
                  .WithErrorMessage("Campo PortalId es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_RoleId_Is_Default()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { RoleId = default };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.RoleId)
                  .WithErrorMessage("Campo RoleId es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_StatusId_Is_Default()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { StatusId = default };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.StatusId)
                  .WithErrorMessage("Campo StatusId es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Username_Is_Empty()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { Username = string.Empty };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Username)
                  .WithErrorMessage("Campo Username es requerido");
        }

        [Fact]
        public void Should_Not_Have_Error_When_CompanyId_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { CompanyId = "60af72ad9a1a256c234bc0b1" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CompanyId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_CreatedOn_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { CreatedOn = DateTime.UtcNow };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CreatedOn);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Email_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { Email = "test@example.com" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Name_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { Name = "John Doe" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Password_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { Password = "P@ssw0rd!" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Not_Have_Error_When_PortalId_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { PortalId = 1 };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.PortalId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_RoleId_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { RoleId = 1 };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.RoleId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_StatusId_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { StatusId = 1 };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.StatusId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Username_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeCrearDTO { Username = "johndoe" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Username);
        }
    }
}

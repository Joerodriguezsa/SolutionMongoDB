using Annarth.Domain.DTO;
using FluentValidation.TestHelper;

namespace Annarth.Test.Domain.DTO
{
    public class EmployeeActulizarDTOTests
    {
        private readonly EmployeeActulizarDTOValidator _validator;

        public EmployeeActulizarDTOTests()
        {
            _validator = new EmployeeActulizarDTOValidator();
        }

        [Fact]
        public void Should_Have_Error_When_CompanyId_Is_Null()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { CompanyId = null };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CompanyId)
                  .WithErrorMessage("Campo CompanyId es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_CompanyId_Is_Empty()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { CompanyId = string.Empty };

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
            var dto = new EmployeeActulizarDTO { CreatedOn = default };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CreatedOn)
                  .WithErrorMessage("Campo CreatedOn es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Null()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { Email = null };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("Campo Email es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Null()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { Name = null };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorMessage("Campo Name es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Null()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { Password = null };

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
            var dto = new EmployeeActulizarDTO { PortalId = default };

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
            var dto = new EmployeeActulizarDTO { RoleId = default };

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
            var dto = new EmployeeActulizarDTO { StatusId = default };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.StatusId)
                  .WithErrorMessage("Campo StatusId es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Username_Is_Null()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { Username = null };

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
            var dto = new EmployeeActulizarDTO { CompanyId = "507f191e810c19729de860ea" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CompanyId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_CreatedOn_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { CreatedOn = DateTime.UtcNow };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CreatedOn);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Email_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { Email = "test@example.com" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Name_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { Name = "John Doe" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Password_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { Password = "P@ssw0rd!" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Not_Have_Error_When_PortalId_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { PortalId = 1 };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.PortalId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_RoleId_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { RoleId = 1 };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.RoleId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_StatusId_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { StatusId = 1 };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.StatusId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Username_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeActulizarDTO { Username = "johndoe" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Username);
        }
    }
}

using Annarth.Domain.DTO;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annarth.Test.Domain.DTO
{
    public class EmployeeConsultarDTOTests
    {
        private readonly EmployeeConsultarDTOValidator _validator;

        public EmployeeConsultarDTOTests()
        {
            _validator = new EmployeeConsultarDTOValidator();
        }

        [Fact]
        public void Should_Have_Error_When_CreatedOn_Is_Default()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { CreatedOn = default };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CreatedOn)
                  .WithErrorMessage("Campo CreatedOn es requerido");
        }

        [Fact]
        public void Should_Have_Error_When_Email_Exceeds_150_Characters()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Email = new string('a', 151) };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("El campo Email no puede exceder los 150 caracteres");
        }

        [Fact]
        public void Should_Have_Error_When_Fax_Exceeds_150_Characters()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Fax = new string('a', 151) };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Fax)
                  .WithErrorMessage("El campo Fax no puede exceder los 150 caracteres");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Exceeds_150_Characters()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Name = new string('a', 151) };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorMessage("El campo Name no puede exceder los 150 caracteres");
        }

        [Fact]
        public void Should_Have_Error_When_Password_Exceeds_150_Characters()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Password = new string('a', 151) };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Password)
                  .WithErrorMessage("El campo Password no puede exceder los 150 caracteres");
        }

        [Fact]
        public void Should_Have_Error_When_Telephone_Exceeds_150_Characters()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Telephone = new string('a', 151) };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Telephone)
                  .WithErrorMessage("El campo Telephone no puede exceder los 150 caracteres");
        }

        [Fact]
        public void Should_Have_Error_When_Username_Exceeds_150_Characters()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Username = new string('a', 151) };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Username)
                  .WithErrorMessage("El campo Username no puede exceder los 150 caracteres");
        }

        [Fact]
        public void Should_Not_Have_Error_When_CreatedOn_Is_Provided()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { CreatedOn = DateTime.UtcNow };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CreatedOn);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Email_Is_Valid()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Email = "test@example.com" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Fax_Is_Valid()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Fax = "123-456-7890" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Fax);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Name_Is_Valid()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Name = "John Doe" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Password_Is_Valid()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Password = "P@ssw0rd!" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Telephone_Is_Valid()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Telephone = "123-456-7890" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Telephone);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Username_Is_Valid()
        {
            // Arrange
            var dto = new EmployeeConsultarDTO { Username = "johndoe" };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Username);
        }
    }
}

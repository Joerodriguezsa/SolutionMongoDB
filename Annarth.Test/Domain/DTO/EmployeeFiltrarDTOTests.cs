using Annarth.Domain.DTO;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annarth.Test.Domain.DTO
{
    public class EmployeeFiltrarDTOTests
    {
        private readonly EmployeeFiltrarDTOValidator _validator;

        public EmployeeFiltrarDTOTests()
        {
            _validator = new EmployeeFiltrarDTOValidator();
        }

        [Fact]
        public void Should_Not_Have_Error_When_Valid_CompanyId_Provided()
        {
            // Arrange
            var dto = new EmployeeFiltrarDTO { CompanyId = 1 };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CompanyId);
        }
                
        [Fact]
        public void Should_Have_Error_When_CompanyName_Exceeds_Max_Length()
        {
            // Arrange
            var dto = new EmployeeFiltrarDTO { CompanyName = new string('A', 101) };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CompanyName)
                  .WithErrorMessage("CompanyName no debe exceder los 100 caracteres");
        }

    }
}

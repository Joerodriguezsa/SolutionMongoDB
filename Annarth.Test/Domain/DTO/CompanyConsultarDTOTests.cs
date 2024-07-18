using Annarth.Domain.DTO;

namespace Annarth.Test.Domain.DTO
{
    public class CompanyConsultarDTOTests
    {
        [Fact]
        public void Should_Set_And_Get_Id()
        {
            // Arrange
            var dto = new CompanyConsultarDTO();
            var id = "507f191e810c19729de860ea";

            // Act
            dto.Id = id;

            // Assert
            Assert.Equal(id, dto.Id);
        }

        [Fact]
        public void Should_Set_And_Get_CompanyName()
        {
            // Arrange
            var dto = new CompanyConsultarDTO();
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
            var dto = new CompanyConsultarDTO();
            var state = true;

            // Act
            dto.State = state;

            // Assert
            Assert.Equal(state, dto.State);
        }
    }
}

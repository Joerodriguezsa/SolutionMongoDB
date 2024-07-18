using Annarth.Domain.Entities;
using MongoDB.Bson;

namespace Annarth.Test.Domain.Entities
{
    public class CompanyTests
    {
        [Fact]
        public void Should_Have_Default_Values()
        {
            // Arrange
            var company = new Company();

            // Act & Assert
            Assert.Equal(ObjectId.Empty, company.Id);
            Assert.Equal(string.Empty, company.CompanyName);
            Assert.False(company.State);
        }

        [Fact]
        public void Should_Set_And_Get_Id()
        {
            // Arrange
            var company = new Company();
            var objectId = ObjectId.GenerateNewId();

            // Act
            company.Id = objectId;

            // Assert
            Assert.Equal(objectId, company.Id);
        }

        [Fact]
        public void Should_Set_And_Get_CompanyName()
        {
            // Arrange
            var company = new Company();
            var companyName = "Test Company";

            // Act
            company.CompanyName = companyName;

            // Assert
            Assert.Equal(companyName, company.CompanyName);
        }

        [Fact]
        public void Should_Set_And_Get_State()
        {
            // Arrange
            var company = new Company();
            var state = true;

            // Act
            company.State = state;

            // Assert
            Assert.True(company.State);
        }
    }
}

using Annarth.Domain;
using Annarth.Infrastructure;
using Microsoft.Extensions.Options;
using Moq;

namespace Annarth.Test.Infrastructure
{
    public class AnnarthMongoDbContextTests
    {
        [Fact]
        public void AnnarthMongoDbContext_ConstructsCorrectly()
        {
            // Arrange
            var settings = new Mock<IOptions<MongoDbSettings>>();
            settings.Setup(s => s.Value).Returns(new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "test_database"
            });

            // Act
            var dbContext = new AnnarthMongoDbContext(settings.Object);

            // Assert
            Assert.NotNull(dbContext);
        }

        [Fact]
        public void AnnarthMongoDbContext_CompaniesCollection_ReturnsExpectedCollection()
        {
            // Arrange
            var settings = new Mock<IOptions<MongoDbSettings>>();
            settings.Setup(s => s.Value).Returns(new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "test_database"
            });

            var dbContext = new AnnarthMongoDbContext(settings.Object);

            // Act
            var companiesCollection = dbContext.Companies;

            // Assert
            Assert.NotNull(companiesCollection);
            Assert.Equal("Company", companiesCollection.CollectionNamespace.CollectionName);
        }

        [Fact]
        public void AnnarthMongoDbContext_EmployeesCollection_ReturnsExpectedCollection()
        {
            // Arrange
            var settings = new Mock<IOptions<MongoDbSettings>>();
            settings.Setup(s => s.Value).Returns(new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "test_database"
            });

            var dbContext = new AnnarthMongoDbContext(settings.Object);

            // Act
            var employeesCollection = dbContext.Employees;

            // Assert
            Assert.NotNull(employeesCollection);
            Assert.Equal("Employee", employeesCollection.CollectionNamespace.CollectionName);
        }
    }
}

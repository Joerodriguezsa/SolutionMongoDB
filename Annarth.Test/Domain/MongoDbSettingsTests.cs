using Annarth.Domain;

namespace Annarth.Test.Domain
{
    public class MongoDbSettingsTests
    {
        [Fact]
        public void Should_Have_Default_Values()
        {
            // Arrange
            var settings = new MongoDbSettings();

            // Act & Assert
            Assert.Equal(string.Empty, settings.ConnectionString);
            Assert.Equal(string.Empty, settings.DatabaseName);
        }

        [Fact]
        public void Should_Set_And_Get_ConnectionString()
        {
            // Arrange
            var settings = new MongoDbSettings();
            var connectionString = "mongodb://localhost:27017";

            // Act
            settings.ConnectionString = connectionString;

            // Assert
            Assert.Equal(connectionString, settings.ConnectionString);
        }

        [Fact]
        public void Should_Set_And_Get_DatabaseName()
        {
            // Arrange
            var settings = new MongoDbSettings();
            var databaseName = "Annarth";

            // Act
            settings.DatabaseName = databaseName;

            // Assert
            Assert.Equal(databaseName, settings.DatabaseName);
        }
    }
}

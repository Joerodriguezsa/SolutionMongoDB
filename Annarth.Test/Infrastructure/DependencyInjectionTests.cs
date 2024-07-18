using Annarth.Application.Interface.IRepository;
using Annarth.Application.Interface.IService;
using Annarth.Domain;
using Annarth.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Annarth.Test.Infrastructure
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void ImplementPersistence_RegistersServicesCorrectly()
        {
            // Arrange
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") // Ajusta esto según tu configuración
                .Build();

            var services = new ServiceCollection();

            // Act
            services.ImplementPersistence(configuration);
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            var mongoDbSettings = serviceProvider.GetService<MongoDbSettings>();
            Assert.NotNull(mongoDbSettings);

            var dbContext = serviceProvider.GetService<AnnarthMongoDbContext>();
            Assert.NotNull(dbContext);

            var employeeService = serviceProvider.GetService<IEmployeeService>();
            Assert.NotNull(employeeService);

            var employeeRepository = serviceProvider.GetService<IEmployeeRepository>();
            Assert.NotNull(employeeRepository);

            var companyService = serviceProvider.GetService<ICompanyService>();
            Assert.NotNull(companyService);

            var companyRepository = serviceProvider.GetService<ICompanyRepository>();
            Assert.NotNull(companyRepository);
        }
    }
}

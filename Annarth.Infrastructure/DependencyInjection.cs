using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Annarth.Infrastructure.Repository;
using Annarth.Domain;
using Annarth.Application.Service;
using Annarth.Application.Interface.IService;
using Annarth.Application.Interface.IRepository;

namespace Annarth.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurar la conexión a MongoDB
            services.Configure<MongoDbSettings>(options =>
            {
                configuration.GetSection("MongoDbSettings").Bind(options);
            });

            // Asegúrate de que MongoDbSettings está registrado correctamente
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddSingleton<AnnarthMongoDbContext>();

            // Registrar servicios específicos para MongoDB
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            return services;
        }
    }
}

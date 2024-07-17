using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Annarth.Application.Interface.IRepository;
using Annarth.Application.Interface.IService;
using Annarth.Application.Service;
using Annarth.Infrastructure.Repository;

namespace Annarth.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AnnarthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("StringConnectionSqlServer")));

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}

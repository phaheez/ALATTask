using ALAT.Core.Interfaces;
using ALAT.Infrastructure.Persistence.Contexts;
using ALAT.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ALAT.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CustomerContext>(options =>
               options.UseSqlServer(defaultConnectionString));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IValuesRepository, ValuesRepository>();

            return services;
        }
    }
}

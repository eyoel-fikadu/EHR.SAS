using EHR.SAS.Common.Application.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practitioner.Application.Common.Abstraction;
using Practitioner.Infrastructure.Persistance;
using Practitioner.Infrastructure.Repository;
using Practitioner.Infrastructure.Service;

namespace Practitioner.Infrastructure
{
    public static class DependencyInjectionExtenstion
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseNpgsql(
                         configuration.GetConnectionString("PostgresConnection"),
                         b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IReadRepository, ReadRepository>();

            services.AddTransient<IDateTime, DateTimeService>();
            
            return services;
        }

    }
}

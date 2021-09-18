using FluentValidation;
using LIS.Infastructure.Data;
using LIS.Infastructure.Repositories.IRepository;
using LIS.Infastructure.Repositories.Repository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LIS.Service
{
    public static class DependencyInjectionExtenstion
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILaboratoryContext, LaboratoryContext>();
            services.AddScoped<ILaboratoryTestRepository, LaboratoryTestRepository>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

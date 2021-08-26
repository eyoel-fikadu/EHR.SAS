using EHR.SAS.Common.Application.Abstraction;
using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Infrastructure.Persistance;
using HospitalMgt.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Infrastructure
{
    public static class DependencyInjectionExtenstion
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                //services.AddDbContext<ApplicationDbContext>(options =>
                //    options.UseInMemoryDatabase("CleanArchitectureDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            //services
                //.AddDefaultIdentity<ApplicationUser>()
                //.AddRoles<IdentityRole>()
                //.AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            //services.AddTransient<IIdentityService, IdentityService>();

            //services.AddAuthentication()
            //    .AddIdentityServerJwt();

            //services.AddAuthorization(options =>
            //{
            //    //options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            //});

            return services;
        }

    }
}

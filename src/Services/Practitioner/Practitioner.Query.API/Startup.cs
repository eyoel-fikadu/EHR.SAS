using EHR.SAS.Common.Application.Abstraction;
using LIS.Grpc.Protos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Practitioner.Application;
using Practitioner.Infrastructure;
using Practitioner.Query.API.GrpcServices;
using Practitioner.Query.API.Services;
using System;

namespace Practitioner.Query.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            
            services.AddHttpContextAccessor();
            
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            
            services.AddScoped<LaboratoryGrpcService>();

            services.AddGrpcClient<LaboratoryProtoService.LaboratoryProtoServiceClient>
                (option => option.Address = new Uri(Configuration["GrpcSettings:LaboratoryUrl"]));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Practitioner.Query.API", Version = "v1" });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practitioner.Query.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using HospitalMgt.API.Middleware;
using HospitalMgt.API.Services;
using HospitalMgt.Application;
using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;

namespace HospitalMgt.API
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

            services.AddMvc(options =>
                options.Filters.Add<ApiExceptionMiddleware>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalMgt", Version = "v1" });
                c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });
            });

            #region Authentication
            // prevent from mapping "sub" claim to nameidentifier.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var identityUrl = Configuration.GetValue<string>("IdentityUrl");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "hospitalmgt";
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalMgt.API v1"));
            }

            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            //app.UseMiddleware<ApiExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

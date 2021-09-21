//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Npgsql;
//using Practitioner.Infrastructure.Persistance;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Practitioner.Infrastructure.Extersntsions
//{
//    public static class MigrateHostExtension
//    {
//        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
//        {
//            int retryForAvialability = retry.Value;
//            using(var scope = host.Services.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                var configuration = services.GetRequiredService<IConfiguration>();
//                var logger = services.GetRequiredService<ILogger<TContext>>();
//                try
//                {
//                    var context = services.GetRequiredService<ApplicationDbContext>();

//                    if (context.Database.IsNpgsql())
//                    {
//                        // fix me
//                        //context.Database.Migrate();
//                    }

//                    //await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);
//                    //await ApplicationDbContextSeed.SeedSampleDataAsync(context);
//                }
//                catch (Exception ex)
//                {
//                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

//                    //throw;
//                }
//                return host;
//            }
//        }
//    }
//}

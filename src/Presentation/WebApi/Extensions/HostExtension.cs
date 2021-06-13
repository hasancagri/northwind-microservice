using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance.EntityFramework;
using Polly;
using System;

namespace CustomerService.WebApi.Extensions
{
    public static class HostExtension
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<NorthwindContext>();
                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(
                    retryCount: 5,
                    sleepDurationProvider: retryCount => TimeSpan.FromSeconds(Math.Pow(2, retryCount)),
                    onRetry: (exception, context) =>
                    {
                        string message = exception.Message;
                    });
                retry.Execute(() => Migrate(context));
            }
            return host;
        }

        private static void Migrate(NorthwindContext context)
        {
            context.Database.Migrate();
            NorthwindContextSeed.SeedData(context)
                .Wait();
        }
    }
}

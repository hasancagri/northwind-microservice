using Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EntityFramework;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddDbContext<NorthwindContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("NorthwindContext")));
            return services;
        }
    }
}

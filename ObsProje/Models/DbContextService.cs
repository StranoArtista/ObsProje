using Microsoft.EntityFrameworkCore;

namespace ObsProje.Models
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services) 
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddDbContextPool<MyContext>(option=>option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());
            
            return services;
        }
    }
}

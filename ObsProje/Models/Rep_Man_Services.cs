using ObsProje.Interfaces;

namespace ObsProje.Models
{
    public static class Rep_Man_Services
    {
        public static IServiceCollection AddRepManServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            //Managers
            services.AddScoped(typeof(IManager<>), typeof(Base_Manager<>));
            return services;
        }
    }
}

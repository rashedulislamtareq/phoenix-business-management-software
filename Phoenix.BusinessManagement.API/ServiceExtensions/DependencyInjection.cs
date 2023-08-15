using Phoenix.BusinessManagement.Repository.Core;
using Phoenix.BusinessManagement.Service.Services;

namespace Phoenix.BusinessManagement.API.ServiceExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSevices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IHealthCheckService, HealthCheckService>();

            return services;
        }
    }
}

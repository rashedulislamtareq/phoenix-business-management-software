using Microsoft.Extensions.DependencyInjection.Extensions;
using Phoenix.BusinessManagement.Repository.Core;
using Phoenix.BusinessManagement.Service.Services;

namespace Phoenix.BusinessManagement.API.ServiceExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IHealthCheckService, HealthCheckService>();

            return services;
        }
    }
}

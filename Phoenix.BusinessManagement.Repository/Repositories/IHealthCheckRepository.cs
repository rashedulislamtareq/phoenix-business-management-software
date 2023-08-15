using Phoenix.BusinessManagement.Entity.Domain.HealthCheck;
using Phoenix.BusinessManagement.Repository.Context;
using Phoenix.BusinessManagement.Repository.Core;

namespace Phoenix.BusinessManagement.Repository.Repositories
{
    public interface IHealthCheckRepository : IBaseRepository<Application>
    {
    }

    public class HealthCheckRepository : BaseRepository<Application>, IHealthCheckRepository
    {
        private readonly IDapperContext _dapper; 

        public HealthCheckRepository(ApplicationDbContext dbContext, IDapperContext dapper) : base(dbContext)
        {
            _dapper = dapper;
        }
    }
}

using Phoenix.BusinessManagement.Repository.Context;
using Phoenix.BusinessManagement.Repository.Repositories;

namespace Phoenix.BusinessManagement.Repository.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDapperContext _dapper;

        public UnitOfWork(ApplicationDbContext dbContext, IDapperContext dapper)
        {
            _dbContext = dbContext;
            _dapper = dapper;

            HealthCheckRepository = new HealthCheckRepository(_dbContext, _dapper);
        }

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IHealthCheckRepository HealthCheckRepository { get; set; }
    }
}

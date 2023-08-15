using Phoenix.BusinessManagement.Repository.Repositories;

namespace Phoenix.BusinessManagement.Repository.Core
{
    public interface IUnitOfWork
    {
        Task<int> Complete();

        public IHealthCheckRepository HealthCheckRepository { get; }
    }
}


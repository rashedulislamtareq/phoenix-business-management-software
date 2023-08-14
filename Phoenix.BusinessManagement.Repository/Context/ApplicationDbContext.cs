using Microsoft.EntityFrameworkCore;
using Phoenix.BusinessManagement.Entity.Domain.HealthCheck;

namespace Phoenix.BusinessManagement.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }

        public DbSet<Application> Application { get; set; }
    }
}

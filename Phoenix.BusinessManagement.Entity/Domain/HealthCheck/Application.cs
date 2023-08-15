namespace Phoenix.BusinessManagement.Entity.Domain.HealthCheck
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Version { get; set; }
    }
}

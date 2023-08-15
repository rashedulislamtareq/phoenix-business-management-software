namespace Phoenix.BusinessManagement.ClientModel.Models.HealthCheck
{
    public class HealthCheckCreateVM
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Version { get; set; }
    }

    public class HealthCheckUpdateVM 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Version { get; set; }
    }

    public class HealthCheckListVM 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Version { get; set; }
    }

    public class HealthCheckDetailVM  : HealthCheckListVM
    {

    }
}

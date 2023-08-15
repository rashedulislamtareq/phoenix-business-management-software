namespace Phoenix.BusinessManagement.Entity.Utility
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public int? StatusCode { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}

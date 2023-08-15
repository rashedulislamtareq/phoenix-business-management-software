namespace Phoenix.BusinessManagement.Entity.Utility
{
    public class ResponseForList
    {
        public ResponseForList(object? collection, int totalElements, int page, int size)
        {
            Collection = collection;
            TotalElements = totalElements;
            Page = page;
            Size = size;

            TotalPage = Convert.ToInt32(Math.Ceiling((decimal)(totalElements / size)));

            HasNext = (Page < TotalPage);
            HasPrevious = (Page > 1);
        }

        public object? Collection { get; set; }
        public int TotalElements { get; set; } = 0;
        public int TotalPage { get; set; } = 1;
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 1;
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}

using Phoenix.BusinessManagement.Entity.Enum;

namespace Phoenix.BusinessManagement.Entity.Utility
{
    public static class PageSizeExtensions
    {
        public static double Width(this PageSize pageSize)
        {
            switch (pageSize)
            {
                case PageSize.A3:
                    return 11.69;
                case PageSize.A4:
                    return 8.27;
                case PageSize.Letter:
                    return 8.5;
                case PageSize.Legal:
                    return 8.5;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Invalid page size.");
            }
        }

        public static double Height(this PageSize pageSize)
        {
            switch (pageSize)
            {
                case PageSize.A3:
                    return 16.54;
                case PageSize.A4:
                    return 11.69;
                case PageSize.Letter:
                    return 11;
                case PageSize.Legal:
                    return 14;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Invalid page size.");
            }
        }
    }
}

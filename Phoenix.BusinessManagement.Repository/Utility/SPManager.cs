using Phoenix.BusinessManagement.Entity.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.BusinessManagement.Repository.Utility
{
    public static class SPManager
    {
        public static ResponseForList FinalPaginatedResult<T>(PaginatedData<T> paginatedData, int page, int size) where T : class
        {
            int totalElement = paginatedData.TotalRows ?? 0;
            return new ResponseForList(paginatedData, totalElement, page, size);
        }

        public static ResponseForList FinalPaginatedResultByNewKey<T>(PaginatedData<T> paginatedData, int page, int size) where T : new()
        {
            int totalElement = paginatedData.TotalRows ?? 0;
            return new ResponseForList(paginatedData, totalElement, page, size);
        }

        public static ResponseForList PreparePaginatedResponse<T>(List<T> data, int totalElements, int page, int size)
        {
            return new ResponseForList(data, totalElements, page, size);
        }
    }
}

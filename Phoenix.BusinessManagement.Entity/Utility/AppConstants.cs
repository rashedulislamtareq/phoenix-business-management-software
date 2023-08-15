using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.BusinessManagement.Entity.Utility
{
    public static class AppConstants
    {
        public enum StatusId : byte
        {
            InActive = 0,
            Active = 1,
            Delete = 2
        }
        public enum ResultStatus
        {
            Success,
            Error,
            Canceled
        }
    }
}

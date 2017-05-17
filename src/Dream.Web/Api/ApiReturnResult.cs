using Dream.Web.Api.ErrorShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream.Web.Api
{
    public class ApiReturnResult
    {
        public bool IsValidate { get; set; }

        public List<ApiError> ErrorLists { get; set; }
    }
}

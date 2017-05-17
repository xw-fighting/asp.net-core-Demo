using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream.Web.Api.ErrorShow
{
    public class ApiError
    {
        public ApiError(string key, string message)
        {
            Key = key;
            Message = message;
        }
        public string Key { get; set; }
        public string Message { get; set; }
    }
}

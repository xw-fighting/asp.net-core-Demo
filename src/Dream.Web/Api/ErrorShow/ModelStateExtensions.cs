using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream.Web.Api.ErrorShow
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<ApiError> AllModelStateErrors(this ModelStateDictionary modelState)
        {
            var result = new List<ApiError>();
            //找到出错的字段以及出错信息
            var errorFieldsAndMsgs = modelState.Where(m => m.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });
            foreach (var item in errorFieldsAndMsgs)
            {
                //获取键
                var fieldKey = item.Key;
                //获取键对应的错误信息
                var fieldErrors = item.Errors
                    .Select(e => new ApiError(fieldKey, e.ErrorMessage));
                result.AddRange(fieldErrors);
            }
            return result;
        }
    }
}

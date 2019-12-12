using viewwerXF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace viewwerXF
{
    static class Extensions
    {
        public static bool IsSuccess(this BaseResponse response)
        {
            return response?.Status == "success" || response?.Status == "completed";
        }

        public static bool IsNull(this string strValue)
        {
            return string.IsNullOrEmpty(strValue) || string.IsNullOrWhiteSpace(strValue);
        }

        public static string ToJson<T>(this T obj) where T : class, new()
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

    }
}

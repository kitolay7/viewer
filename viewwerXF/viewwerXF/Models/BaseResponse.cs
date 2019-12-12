using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace viewwerXF.Models
{
    public class BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("result")]
        public string Result { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("taskId")]
        public string TaskId { get; set; }
        [JsonProperty("uploadUrl")]
        public string Url { get; set; }
        [JsonProperty("url")]
        public string ResultUrl { get; set; }
        [JsonProperty("uploadApiKey")]
        public string ApiKey { get; set; }

      
    }
}

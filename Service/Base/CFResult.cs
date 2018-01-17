using Newtonsoft.Json;

namespace Service.Base
{
    public class CFResult
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public object Errors { get; set; }

        public string ID { get; set; }

        public object Extra { get; set; }
    }
}

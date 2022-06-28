using Newtonsoft.Json;

namespace ClickMeeting.Models
{
    public class AutologinHashes
    {
        [JsonProperty("host")]
        public string Host { get; set; }
    }
}

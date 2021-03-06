using Newtonsoft.Json;

namespace ClickMeeting.Models
{
    public class AccessToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("sent_to_email")]
        public string SentToEmail { get; set; }

        [JsonProperty("first_use_date")]
        public DateTime? FirstUseDate { get; set; }
    }
}

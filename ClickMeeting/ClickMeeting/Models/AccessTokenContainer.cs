using Newtonsoft.Json;

namespace ClickMeeting.Models
{
    public class AccessTokenContainer
    {
        [JsonProperty("access_tokens")]
        public List<AccessToken> AccessTokens { get; set; }
    }
}

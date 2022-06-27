using Newtonsoft.Json;
namespace ClickMeeting.ClickMeeting
{
    public class AutologinResult
    {
        [JsonProperty("autologin_hash")]
        public string AutologinHash { get; set; }
    }
}

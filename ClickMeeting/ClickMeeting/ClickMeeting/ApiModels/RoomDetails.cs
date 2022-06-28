using ClickMeeting.Models;
using Newtonsoft.Json;

namespace ClickMeeting.ClickMeeting.ApiModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


    public class Settings
    {
        [JsonProperty("show_on_personal_page")]
        public bool ShowOnPersonalPage { get; set; }

        [JsonProperty("thank_you_emails_enabled")]
        public bool ThankYouEmailsEnabled { get; set; }

        [JsonProperty("connection_tester_enabled")]
        public bool ConnectionTesterEnabled { get; set; }

        [JsonProperty("phonegateway_enabled")]
        public bool PhonegatewayEnabled { get; set; }
    }


}

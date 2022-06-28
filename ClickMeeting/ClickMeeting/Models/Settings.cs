using Newtonsoft.Json;
using System;
using System.Linq;

namespace ClickMeeting.Models
{
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
        [JsonProperty("recorder_autostart_enabled")]
        public bool RecorderAutostartEnabled { get; set; }
        [JsonProperty("room_invite_button_enabled")]
        public bool RoomInviteButtonEnabled { get; set; }
        [JsonProperty("social_media_sharing_enabled")]
        public bool SocialMediaSharingEnabled { get; set; }
        [JsonProperty("connection_status_enabled")]
        public bool ConnectionStatusEnabled { get; set; }
        [JsonProperty("thank_you_page_url")]
        public string? ThankYouPageUrl { get; set; }
    }
}

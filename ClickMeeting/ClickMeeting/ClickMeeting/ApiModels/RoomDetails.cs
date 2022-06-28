﻿using Newtonsoft.Json;

namespace ClickMeeting.ClickMeeting.ApiModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AccessRoleHashes
    {
        [JsonProperty("listener")]
        public string Listener { get; set; }

        [JsonProperty("presenter")]
        public string Presenter { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }
    }

    public class AutologinHashes
    {
        [JsonProperty("host")]
        public string Host { get; set; }
    }

    public class Room
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent_id")]
        public object ParentId { get; set; }

        [JsonProperty("room_type")]
        public string RoomType { get; set; }

        [JsonProperty("room_pin")]
        public int RoomPin { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_url")]
        public string NameUrl { get; set; }

        [JsonProperty("access_type")]
        public int AccessType { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("lobby_enabled")]
        public bool LobbyEnabled { get; set; }

        [JsonProperty("lobby_description")]
        public string LobbyDescription { get; set; }

        [JsonProperty("registration_enabled")]
        public int RegistrationEnabled { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }

        [JsonProperty("paid_enabled")]
        public int PaidEnabled { get; set; }

        [JsonProperty("automated_enabled")]
        public int AutomatedEnabled { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("permanent_room")]
        public bool PermanentRoom { get; set; }

        [JsonProperty("access_role_hashes")]
        public AccessRoleHashes AccessRoleHashes { get; set; }

        [JsonProperty("room_url")]
        public string RoomUrl { get; set; }

        [JsonProperty("phone_presenter_pin")]
        public int PhonePresenterPin { get; set; }

        [JsonProperty("phone_listener_pin")]
        public int PhoneListenerPin { get; set; }

        [JsonProperty("embed_room_url")]
        public string EmbedRoomUrl { get; set; }

        [JsonProperty("widgets_hash")]
        public string WidgetsHash { get; set; }

        [JsonProperty("recorder_list")]
        public List<object> RecorderList { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("autologin_hashes")]
        public AutologinHashes AutologinHashes { get; set; }

        [JsonProperty("autologin_hash")]
        public string AutologinHash { get; set; }
    }

    public class RoomDetails
    {
        [JsonProperty("conference")]
        public Room Conference { get; set; }
    }

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

using Newtonsoft.Json;
using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class AccessRoleHashes
    {
        [JsonProperty("listener")]
        public string Listener { get; set; }

        [JsonProperty("presenter")]
        public string Presenter { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }
    }
}

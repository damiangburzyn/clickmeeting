using Newtonsoft.Json;

namespace ClickMeeting.Models
{
    public class RoomDetails
    {
        [JsonProperty("conference")]
        public Room Conference { get; set; }
    }

}

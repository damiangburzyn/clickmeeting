using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Room
    {
        public string embed_room_url { get; set; }
        public string status { get; set; }
        public int access_type { get; set; }
        public string room_type { get; set; }
        public string name_url { get; set; }
        public DateTime updated_at { get; set; }
        public string lobby_description { get; set; }
        public int room_pin { get; set; }
        public int phone_presenter_pin { get; set; }
        public int phone_listener_pin { get; set; }
        public string name { get; set; }
        public string lobby_enabled { get; set; }
        public int id { get; set; }
        public string room_url { get; set; }
        public string timezone { get; set; }
        public int registration_enabled { get; set; }
        public int timezone_offset { get; set; }
        public AccessRoleHashes access_role_hashes { get; set; }
        public DateTime created_at { get; set; }
        public List<string> recorder_list { get; set; }
        public string widgets_hash { get; set; }
        public bool permanent_room { get; set; }
        public Settings settings { get; set; }
    }
}

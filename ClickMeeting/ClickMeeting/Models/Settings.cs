using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Settings
    {
        public bool show_on_personal_page { get; set; }
        public bool thank_you_emails_enabled { get; set; }
        public bool connection_tester_enabled { get; set; }
        public bool phonegateway_enabled { get; set; }
        public bool recorder_autostart_enabled { get; set; }
        public bool room_invite_button_enabled { get; set; }
        public bool social_media_sharing_enabled { get; set; }
        public bool connection_status_enabled { get; set; }
        public string thank_you_page_url { get; set; }
    }
}

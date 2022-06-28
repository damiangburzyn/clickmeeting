using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Registration
    {
        public DateTime registration_date { get; set; }
        public string registration_confirmed { get; set; }
        public Fields fields { get; set; }
        public int id { get; set; }
        public int session_id { get; set; }
        public string email { get; set; }
        public string visitor_nickname { get; set; }
    }
}

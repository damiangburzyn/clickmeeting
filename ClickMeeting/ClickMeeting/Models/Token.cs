using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Token
    {
        public string token { get; set; }
        public string sent_to_email { get; set; }
        public DateTime first_use_date { get; set; }
    }
}

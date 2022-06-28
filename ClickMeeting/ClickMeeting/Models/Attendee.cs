using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Attendee
    {
        public string device { get; set; }
        public string uid { get; set; }
        public string rating { get; set; }
        public string nickname { get; set; }
        public string role { get; set; }
        public string rating_comment { get; set; }
        public string email { get; set; }
        public List<Poll> polls { get; set; }
    }
}

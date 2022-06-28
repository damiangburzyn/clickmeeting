using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Poll
    {
        public List<Question> questions { get; set; }
        public string name { get; set; }
    }
}

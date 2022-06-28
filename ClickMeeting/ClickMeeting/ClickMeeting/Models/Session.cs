using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Session
    {
        public int max_visitors { get; set; }
        public int id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int total_visitors { get; set; }
    }
}

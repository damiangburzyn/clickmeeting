using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Record
    {
        public int id { get; set; }
        public int recording_duration { get; set; }
        public string recorder_started { get; set; }
        public int recording_file_size { get; set; }
        public string recording_url { get; set; }
    }
}

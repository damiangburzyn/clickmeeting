using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class FileDetail
    {
        public string status { get; set; }
        public string url { get; set; }
        public string document_type { get; set; }
        public int id { get; set; }
        public int conversion_progress { get; set; }
        public string status_message { get; set; }
        public string name { get; set; }
        public string upload_date { get; set; }
    }
}

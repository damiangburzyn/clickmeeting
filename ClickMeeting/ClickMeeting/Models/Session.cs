using Newtonsoft.Json;
using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Session
    {
        [JsonProperty("max_visitors")]
        public int MaxVisitors { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("total_visitors")]
        public int TotalVisitors { get; set; }
    }
}

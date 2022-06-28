using System;
using System.Linq;

namespace ClickMeeting.Models
{
    public class Question
    {
        public string question { get; set; }
        public List<Answer> answers { get; set; }
    }
}

using System.ComponentModel;

namespace ClickMeeting.ClickMeeting.ApiModels
{
    public enum ConferenceStatus
    {
        [Description("active")]
        Active,
        [Description("inactive")]
        Inactive,
    }
}

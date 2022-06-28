
using ClickMeeting.ClickMeeting.ApiModels;

namespace ClickMeeting.ClickMeeting
{
    public interface IClickMeetingApiClient
    {
        Task<AutologinResult> GetAutologinHash(string roomId, string email, string username, string password, string token);
        string GetAutologinURL(AutologinResult autologinHash, string roomURL);
        Task<RoomDetails> GetRoomConferences(string roomId);
        Task<IEnumerable<Conference>> GetConferences(ConferenceStatus status, int page = 1);
    }
}
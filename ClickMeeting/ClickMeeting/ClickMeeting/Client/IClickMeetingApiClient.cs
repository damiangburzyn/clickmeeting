
namespace ClickMeeting.ClickMeeting
{
    public interface IClickMeetingApiClient
    {
        Task<AutologinResult> GetAutologinHash(string roomId, string email, string username, string password, string token);
        string GetAutologinURL(AutologinResult autologinHash, string roomURL);
    }
}
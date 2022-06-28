
using ClickMeeting.ClickMeeting.ApiModels;
using ClickMeeting.Models;

namespace ClickMeeting.ClickMeeting
{
    public interface IClickMeetingApiClient
    {
        Task<AutologinResult> GetAutologinHash(string roomId, string email, string username, string password, string token);
        Task<AutologinResult> GetAutologinHash(Room room, string email, string username);
        string GetAutologinURL(AutologinResult autologinHash, string roomURL);
        Task<RoomDetails> GetRoomConferences(string roomId);
        Task<Room> GetRoom(string roomId);
        Task<IEnumerable<RoomDetails>> GetConferences(ConferenceStatus status, int page = 1);
        Task<IEnumerable<Room>> GetConferenceRooms(ConferenceStatus status, int page = 1);
    }
}

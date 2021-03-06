using ClickMeeting.ClickMeeting.ApiModels;
using ClickMeeting.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ClickMeeting.ClickMeeting
{
    public class ClickMeetingApiClient : IClickMeetingApiClient
    {
        private readonly ClickMeetingApiConfig _clickMeetingConfig;
        private readonly HttpClient _client;
        public ClickMeetingApiClient(IOptions<ClickMeetingApiConfig> clickMeetingConfig)
        {
            _clickMeetingConfig = clickMeetingConfig.Value;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add(_clickMeetingConfig.KeyName, _clickMeetingConfig.ApiKey);
        }

        public async Task<AutologinResult> GetAutologinHash(string roomId,
            string email,
            string username,
            string password,
            string token)
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{roomId}/room/autologin_hash";
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("email", email));
            formData.Add(new KeyValuePair<string, string>("nickname", username));
            formData.Add(new KeyValuePair<string, string>("role", "listener"));
            formData.Add(new KeyValuePair<string, string>("password", password));
            formData.Add(new KeyValuePair<string, string>("token", token));
            var formContent = new FormUrlEncodedContent(formData);

            var jsonResult = await _client.PostAsync(url, formContent);
            var jsonString = await jsonResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AutologinResult>(jsonString);
            return result;
        }

        public async Task<AutologinResult> GetAutologinHash(Room room, string email, string username, string token = "")
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{room.Id}/room/autologin_hash";
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("email", email));
            formData.Add(new KeyValuePair<string, string>("nickname", username));
            formData.Add(new KeyValuePair<string, string>("role", "listener"));
            formData.Add(new KeyValuePair<string, string>("password", room.Password));
            formData.Add(new KeyValuePair<string, string>("token", token));
            var formContent = new FormUrlEncodedContent(formData);

            var jsonResult = await _client.PostAsync(url, formContent);
            var jsonString = await jsonResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AutologinResult>(jsonString);
            return result;
        }


        public string GetAutologinURL(AutologinResult autologinHash, string roomURL)
        {
            return $"{roomURL}?l={autologinHash.AutologinHash}";
        }

        public async Task<RoomDetails> GetRoomConferences(string roomId)
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{roomId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(request);
            //if (response.IsSuccessStatusCode)
            //{              
            //}
            //else
            //{
            //}
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RoomDetails>(jsonString);
            return result;
        }

        public async Task<Room> GetRoom(string roomId)
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{roomId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Nie mo??na pobra?? danych pokoju!");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Room>(jsonString);
            return result;
        }


        ///TODO: pobierane jest tylko 250 wynik??w, trzeba pobra?? ile mo??na wynik??w w p??tli.
        public async Task<IEnumerable<RoomDetails>> GetConferences(ConferenceStatus status, int page = 1)
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{status.GetDescription()}?page={page}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<RoomDetails>>(jsonString);
            return result;
        }

        public async Task<IEnumerable<Room>> GetConferenceRooms(ConferenceStatus status, int page = 1)
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{status.GetDescription()}?page={page}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Room>>(jsonString);
            return result;
        }

        public async Task<AccessTokenContainer> GenerateAccessToken(int roomId, int howMany = 1)
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{roomId}/tokens";
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("how_many", howMany.ToString()));
            var formContent = new FormUrlEncodedContent(formData);
            var jsonResult = await _client.PostAsync(url, formContent);
            var jsonString = await jsonResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AccessTokenContainer>(jsonString);
            return result;
        }

        public async Task<AccessTokenContainer> GetAccessTokens(int roomId)
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{roomId}/tokens";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AccessTokenContainer>(jsonString);
            return result;
        }

        public async Task<IEnumerable<Session>> RoomSessions(int roomId)
        {
            var url = $"{_clickMeetingConfig.BaseUrl}/conferences/{roomId}/sessions";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Session>>(jsonString);
            return result;
        }
    }
}

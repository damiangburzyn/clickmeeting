using ClickMeeting.ClickMeeting;
using ClickMeeting.ClickMeeting.ApiModels;
using ClickMeeting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace ClickMeeting.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IClickMeetingApiClient _cmClient;

        public HomeController(IClickMeetingApiClient cmClinent,
            ILogger<HomeController> logger)
        {
            _logger = logger;
            _cmClient = cmClinent;
        }

        public async Task<IActionResult> WebinarWithPassword()
        {
            string meetingName = "clickmeeting-test";

            string resultUrl = string.Empty;
            var email = "damian.gburzyn@gmail.com";
            //tego ponizej nie musimy już hardkodowac, wydłubiemy z Room
            //var roomId = "6674551";
            //var password = "clickmeeting";
            //var token = string.Empty;
            string username = "testowyUser";
            try
            {
                //tu jest paging pobiera tylko pierwsze 250 elememntów
                var rooms = await _cmClient.GetConferenceRooms(ConferenceStatus.Active, 1);                
                var room = rooms.Where(n => n.Name.Equals(meetingName)).FirstOrDefault();

                if (room != null)
                {
                    // z room można wyciagnąć Id, Password
                    var result = await _cmClient.GetAutologinHash(room, email, username);

                    //mały sukces TEN URL MOŻNA PODAĆ JAKO IFRAME !!!!!!!!!!!!!!! :)
                    //elegancko :)
                    resultUrl = _cmClient.GetAutologinURL(result, room.RoomUrl);
                }
                else
                {
                    throw new Exception($"Nie można otworzyć pokoju webinara {meetingName} :(");
                }
            }
            catch (Exception ex)
            { 
                _logger.LogError("Message", ex); 
            }

            return View("WebinarWithPassword", resultUrl);
        }


        public IActionResult Embeded()
        {
            return View();
        }

        public async Task<IActionResult> WebinarWithToken()
        {
            string meetingName = "tokenRoom";

            string resultUrl = string.Empty;
            var email = "damian.gburzyn@gmail.com";
            string username = "testowyUser";
            try
            {
                //tu jest paging pobiera tylko pierwsze 250 elememntów
                var rooms = await _cmClient.GetConferenceRooms(ConferenceStatus.Active, 1);
                var room = rooms.Where(n => n.Name.Equals(meetingName)).FirstOrDefault();

                if (room != null)
                {
                    var tokens = await _cmClient.GetAccessTokens(room.Id);
                    var currentToken = tokens?.AccessTokens?.FirstOrDefault(a => a?.SentToEmail == email || string.IsNullOrEmpty(a?.SentToEmail));
                    if (currentToken == null)
                    {
                        tokens = await _cmClient.GenerateAccessToken(room.Id);
                        currentToken = tokens?.AccessTokens?.FirstOrDefault(a => string.IsNullOrEmpty(a?.SentToEmail));

                    }
                    // z room można wyciagnąć Id, Password
                    var result = await _cmClient.GetAutologinHash(room, email, username, currentToken.Token);

                    //mały sukces TEN URL MOŻNA PODAĆ JAKO IFRAME !!!!!!!!!!!!!!! :)
                    //elegancko :)
                    resultUrl = _cmClient.GetAutologinURL(result, room.RoomUrl);
                }
                else
                {
                    throw new Exception($"Nie można otworzyć pokoju webinara {meetingName} :(");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Message", ex);
            }
            return View("WebinarWithToken", resultUrl);
        }


        public async Task<IActionResult> VideoForRequest()
        {
            string meetingName = "Pokój 2"; ;


            string resultUrl = string.Empty;
            var email = "jan.k@kowal.pl";
            string username = "Jan Kowalski";
            try
            {
                var rooms = await _cmClient.GetConferenceRooms(ConferenceStatus.Active, 1);
                var room = rooms.Where(n => n.Name.Equals(meetingName)).FirstOrDefault();

                if (room != null)
                {
                    var result = await _cmClient.GetAutologinHash(room, email, username);

                    resultUrl = _cmClient.GetAutologinURL(result, room.RoomUrl);
                }
                else
                {
                    throw new Exception($"Nie można otworzyć wideo na życzenie {meetingName} :(");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Message", ex);
            }

            return View("VideoForRequest", resultUrl);

        }

        public async Task<IActionResult> WebinarForRequest()
        {
            string meetingName = "RequestRoom"; ;

            string resultUrl = string.Empty;
            var email = "jan.k@kowal.pl";
            string username = "Jan Kowalski";
            try
            {
                var rooms = await _cmClient.GetConferenceRooms(ConferenceStatus.Active, 1);
                var room = rooms.Where(n => n.Name.Equals(meetingName)).FirstOrDefault();

                if (room != null)
                {
                    var result = await _cmClient.GetAutologinHash(room, email, username);

                    resultUrl = _cmClient.GetAutologinURL(result, room.RoomUrl);
                }
                else
                {
                    throw new Exception($"Nie można otworzyć webinara na życzenie {meetingName} :(");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Message", ex);
            }

            return View("WebinarForRequest", resultUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

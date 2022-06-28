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

        public async Task<IActionResult> Index()
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

            return View("Index", resultUrl);
        }

        public IActionResult Privacy()
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

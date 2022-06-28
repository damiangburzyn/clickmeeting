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

            var email = "damian.gburzyn@gmail.com";
            var roomId = "6674551";
            var password = "clickmeeting";
            var token = string.Empty;
            string username = "testowyUser";
            try
            {
                var conferences = await _cmClient.GetConferences(ConferenceStatus.Active, 1);
                  var result = await _cmClient.GetAutologinHash(roomId, email, username, password, token);
                var conference = conferences.FirstOrDefault(a=> a.Name == "")

            }
            catch (Exception ex)
            { _logger.LogError("Message", ex); }

            return View();
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
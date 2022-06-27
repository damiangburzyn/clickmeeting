using ClickMeeting.ClickMeeting;
using ClickMeeting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            var roomId = "clickmeeting-test";
            var password = "clickmeeting";
            var token = string.Empty;
            string username = "testowyUser";
            try {
                
                var result = await _cmClient.GetAutologinHash(roomId, email, username, password, token); }
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
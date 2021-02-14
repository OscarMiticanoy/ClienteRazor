using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClienteRazor.Models;
using System.Net;
using Newtonsoft.Json;

namespace ClienteRazor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Result> person = new List<Result>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string Url = "https://localhost:44326/api/agreement";
            WebClient wc = new WebClient();
            var perso = wc.DownloadString(Url);
            var rs = JsonConvert.DeserializeObject<Persona>(perso);
            foreach(var pe in rs.results)
            {
                person.Add(pe);
            }
            return View(person);
        }

        public IActionResult gridGetData()
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoreMvcWebsite.Models;
using Couchbase;
using Couchbase.Core;
using CouchBaseCaching;

namespace CoreMvcWebsite.Controllers
{
    public class HomeController : Controller
    {
        private static IBucket _bucket;
        public IActionResult Index()
        {
            //ClusterHelper.Initialize(
            //    new ClientConfiguration
            //    {
            //        Servers = new List<Uri> { new Uri("http://localhost:8091") },
            //    },
            //    new PasswordAuthenticator("app", "123456"));

            _bucket = ClusterHelper.GetBucket("Games");

            const string query = "SELECT id, name, year, imageUrl FROM `Games`";

            var games = _bucket.Query<Game>(query).Rows;

            return View(games);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GameInfo()
        {
            return PartialView("_GameInfoPartial");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

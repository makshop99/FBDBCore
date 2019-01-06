using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FBDBWeb.Models;
using FBDBCoreLib.weather.data;
using System.Collections;

namespace FBDBWeb.Controllers
{
    public class HomeController : Controller
    {
        private static WebModel oModel = new WebModel();
        public IActionResult Index()
        {
            // initialisierung des models

            return View();
        }


        #region Game
        public IActionResult GameAnalysis()
        {
            return View();
        }

        public IActionResult GameResult(string HomeTeam, string AwayTeam)
        {
            // Daten aus dem Request lesen
            ViewData["Result"] = oModel.analyseGame(AwayTeam, HomeTeam);

            return View();
        }
        #endregion

        #region Gameday
        public IActionResult GamedayAnalysis()
        {
            return View();
        }

        public IActionResult GamedayResult (string Gameday)
        {
            ViewData["Result"] = oModel.analyseGameday(Gameday);
            return View();
        }
        #endregion

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult Weather()
        {
            Hashtable oData = oModel.getWeather();
            ViewData["TeamWeather"] = oData;
            ViewData["TestString"] = "Hello";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

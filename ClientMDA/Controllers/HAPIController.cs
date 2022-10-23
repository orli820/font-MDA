using ClientMDA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace ClientMDA.Controllers
{
    public class HAPIController : Controller
    {
        private readonly ILogger<HAPIController> _logger;
        private readonly MDAContext _MDA;

        public HAPIController(ILogger<HAPIController> logger, MDAContext MDA)
        {
            _MDA = MDA;
            _logger = logger;
        }

        public IActionResult checklogink()
        {
            if (!HttpContext.Session.Keys.Contains(ADictionary.SK_LOGINED_USER))
                return RedirectToAction("~/Member/Login");
            return View();

        }
        public IActionResult getRank()
        {
            var rank = _MDA.電影排行movieRanks.Where(p => p.電影movie != null).Select(p => p.電影movie).ToString();
            var movietitle = _MDA.電影movies.Where(m => m.中文標題titleCht == rank).Select(m => m.中文標題titleCht).ToList();
            var movieposter = _MDA.電影圖片總表movieImages.Where(p => p.電影名稱movieName == rank).Select(p => p.圖片雲端imageImdb).ToList();
            return Json(movietitle, movieposter);

        }
        public IActionResult showrankposter()
        {
            //var rank = _MDA.電影排行movieRanks.Where(p => p.電影movie != null).Select(p => p.電影movie).ToString();           
            //var movieposter = _MDA.電影圖片總表movieImages.Where(p => p.電影名稱movieName == rank).Select(p => p.圖片雲端imageImdb);
            var q = from a in _MDA.電影排行movieRanks
                    where a.電影movie != null
                    select a;
            return Json(q);

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

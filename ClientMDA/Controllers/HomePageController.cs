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
    public class HomePageController : Controller
    {
        private readonly ILogger<HomePageController> _logger;
        private readonly MDAContext _MDA;

        public HomePageController(ILogger<HomePageController> logger, MDAContext MDA)
        {
            _MDA = MDA;
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();

        }

        public IActionResult showrankposter()
        {
            //var rank = _MDA.電影排行movieRanks.Where(p => p.電影movie != null).Select(p => p.電影movie).ToString();           
            //var movieposter = _MDA.電影圖片總表movieImages.Where(p => p.電影名稱movieName == rank).Select(p => p.圖片雲端imageImdb);
            var q = from a in _MDA.電影movies
                    where a.英文標題titleEng != null
                    select a;
            return Json(q);

        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //public IActionResult test()
        //{
        //    return View();
        //}

    }
}

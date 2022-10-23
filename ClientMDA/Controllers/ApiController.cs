using ClientMDA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClientMDA.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;
        private readonly MDAContext _MDA;

        public ApiController(ILogger<ApiController> logger, MDAContext MDA)
        {
            _logger = logger;
            _MDA = MDA;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult checklogink()
        {
            if (!HttpContext.Session.Keys.Contains(ADictionary.SK_LOGINED_USER))
                return RedirectToAction("~/Member/Login");
            return View();

        }

        //public IActionResult getRank()
        //{
        //    var rank = _MDA.電影排行movieRanks.Where(p => p.電影movie != null).Select(p => p.電影movie).ToString();
        //    var movietitle = _MDA.電影movies.Where(m => m.中文標題titleCht == rank).Select(m => m.中文標題titleCht).ToList();
        //    var movieposter = _MDA.電影圖片總表movieImages.Where(p => p.電影名稱movieName == rank).Select(p => p.圖片雲端imageImdb).ToList();
        //    return Json(movietitle, movieposter);

        //}
        public IActionResult showrankposter()
        {
            var q = from a in _MDA.電影圖片總表movieImages
                    join b in _MDA.電影排行movieRanks on a.電影名稱movieName equals b.電影movie
                    where a.電影名稱movieName == b.電影movie 
                    orderby b.排行編號rankId ascending
                    select a.圖片雲端imageImdb;
            return Json(q);           
        }

        public IActionResult showrankmovie()
        {
            var q1 = from a in _MDA.電影排行movieRanks
                    where a.電影排行movieRank1!=null
                    select a.電影movie;
            return Json(q1);
        }
    }
}

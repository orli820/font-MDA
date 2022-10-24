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
        Random rd = new Random();

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

        public IActionResult shownewmovie()
        {
            var q2 = from a in _MDA.電影movies
                     //改-7&7
                     where a.上映日期releaseDate>= (DateTime.Now.AddDays(-7)) && a.上映日期releaseDate <= (DateTime.Now.AddDays(7))
                     select a.中文標題titleCht;           
            return Json(q2);
        }

        public IActionResult shownewposter()
        {
            var q = _MDA.電影圖片movieIimagesLists.Where(m => m.電影編號movie.上映日期releaseDate >= (DateTime.Now.AddDays(-8)) && m.電影編號movie.上映日期releaseDate <= (DateTime.Now.AddDays(15))).Select(u => u.圖片編號image.圖片雲端imageImdb);
            return Json(q);
        }

        public IActionResult showrecommendposter()
        {
            List<int> list = new List<int>(0);
            var q = _MDA.電影圖片movieIimagesLists.Where(m => m.電影編號movie.上映日期releaseDate < DateTime.Now.AddDays(-30)).Select(u => u.圖片編號image.圖片雲端imageImdb);
            
            //int[] recommend = { rd.Next(1,q.Count()), rd.Next(1, q.Count()), rd.Next(1, q.Count()), rd.Next(1, q.Count()), rd.Next(1, q.Count()), rd.Next(1, q.Count()), rd.Next(1, q.Count()), rd.Next(1, q.Count()), rd.Next(1, q.Count()), rd.Next(1, q.Count()) };

            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    number = rd.Next(1, q.Count());
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            for (int i = 0; i < listNumbers.Count(); i++)
            {
                var q2 = _MDA.電影圖片movieIimagesLists.Where(p => p.電影編號movieId == listNumbers[i]).FirstOrDefault();
                list.Add(q2.電影編號movieId);
            }

            return Json(list);
        }

        //public IActionResult showrecommendmovie()
        //{
        //    var q = _MDA.電影movies.Where(m => m.上映日期releaseDate < DateTime.Now.AddDays(-30)).Select(u => u.中文標題titleCht);
        //    return Json(q);
        //}
    }
}

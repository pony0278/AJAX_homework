using AJAX作業.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAX作業.Controllers
{

    public class ApiController : Controller
    {

        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;
        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }


        public IActionResult ChecknumberAvailability([FromBody] CheckNumberModel model)
        {
            bool isNumberFive = model.Number == 5;

            if (isNumberFive)
            {
                return Content("NO");
            }
            else
            {
                return Content("YES");
            }
        }

        public class CheckNumberModel
        {
            public int Number { get; set; }
        }


        public IActionResult Cities()
        {
            var cities = _context.Address.Select(c => c.City).Distinct();
            return Json(cities);
        }

        //根據城市名稱，回傳城市的鄉鎮區JSON資料
        public IActionResult Districts(string city)
        {
            var districts = _context.Address.Where(a => a.City == city).Select(c => c.SiteId).Distinct();

            return Json(districts);
        }

        //根據鄉鎮區名稱，回傳鄉鎮區的路名JSON資料
        public IActionResult Roads(string siteId)
        {
            var roads = _context.Address.Where(a => a.SiteId == siteId).Select(c => c.Road).Distinct();

            return Json(roads);
        }

    }
}

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

            [HttpPost]
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


    }
}

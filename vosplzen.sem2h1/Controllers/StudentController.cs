using Microsoft.AspNetCore.Mvc;
using vosplzen.sem2h1.Data;

namespace vosplzen.sem2h1.Controllers
{

    [ApiController]
    [Route("Students")]
    public class DatetimeController : Controller
    {

        private ApplicationDbContext _context;

        public DatetimeController(ApplicationDbContext context) {

            _context = context;
        }
        
        [HttpGet]
        [Route("List")]
        public IActionResult Getlist()
        {

            var result = _context.Students.ToList();
            return new JsonResult(result);

        }




    }
}

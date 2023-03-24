using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using vosplzen.sem2h1.Data;

namespace vosplzen.sem2h1.Controllers
{

    [ApiController]
    [Route("Students")]
    public class StudentController : Controller
    {

        private ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context) {

            _context = context;
        }
        
        [HttpGet]
        [Route("List")]
        public IActionResult Getlist()
        {

            var result = _context.Students.ToList();
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("First")]
        public IActionResult GetFirst()
        {

            var result = _context.Students.FirstOrDefault();
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Top")]
        public IActionResult GetTop(int topCount, string? orderBy = "surname") {
            
            if(topCount <= 0) { return BadRequest(); }

            if (orderBy == "name")
            {
                return new JsonResult(_context.Students.Take(topCount).OrderBy(x => x.Name).ToList());
            }
            else {

                return new JsonResult(_context.Students.Take(topCount).OrderBy(x => x.Surname).ToList());
            }
        }

    }
}

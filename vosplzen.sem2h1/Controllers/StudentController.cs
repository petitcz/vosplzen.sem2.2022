using MethodTimer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Data.Dto;
using vosplzen.sem2h1.Data.Model;
using vosplzen.sem2h1.Filters;
using vosplzen.sem2h1.Services.Interfaces;

namespace vosplzen.sem2h1.Controllers
{

    [ApiController]
    [Route("Students")]
    public class StudentController : Controller
    {
        IStudentService _studentservice;
        public StudentController(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult Getlist()
        {
            return new JsonResult(_studentservice.GetList());
         
        }


        [IdentityFilter]
        [Time]
        [HttpPost]
        [Route("Add")]
        public IActionResult PostStudents(List<StudentDto> studentsDto)
        {
            return Ok(_studentservice.AddStudents(studentsDto));
        }
    }

}

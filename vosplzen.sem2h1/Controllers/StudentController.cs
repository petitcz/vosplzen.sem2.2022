﻿using MethodTimer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Data.Dto;
using vosplzen.sem2h1.Data.Model;
using vosplzen.sem2h1.Filters;
using vosplzen.sem2h1.Services;
using vosplzen.sem2h1.Services.Interfaces;

namespace vosplzen.sem2h1.Controllers
{

    [ApiController]
    [Route("Students")]
    public class StudentController : Controller
    {
        IStudentService _studentservice;
        IMasterSeedService _masterseedservice;
        ILogger<StudentController> _log;
        public StudentController(IStudentService studentservice, IMasterSeedService masterseedservice, ILogger<StudentController> log) 
        {
            _masterseedservice = masterseedservice;
            _studentservice = studentservice;
            _log = log;
        }



    [HttpGet]
    [Route("Seed")]
    public IActionResult Seed()
    {

            _log.LogInformation("Seed method has been called");

            _masterseedservice.InitSeed();
             return Ok();
    }

    [IdentityFilter]
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

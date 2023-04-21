using Microsoft.EntityFrameworkCore;
using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Data.Dto;
using vosplzen.sem2h1.Data.Model;

namespace vosplzen.sem2h1.Services.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetList();

        StudentResponseDto AddStudents(List<StudentDto> studentsDto);
    }
}

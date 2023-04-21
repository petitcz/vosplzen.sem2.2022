using Microsoft.EntityFrameworkCore;
using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Data.Dto;
using vosplzen.sem2h1.Data.Model;
using vosplzen.sem2h1.Services.Interfaces;

namespace vosplzen.sem2h1.Services
{

    public class StudentService: MasterSeedService, IStudentService
    {
        public StudentService(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public StudentResponseDto AddStudents(List<StudentDto> studentsDto)
        {
            StudentResponseDto responseDto = new StudentResponseDto();
            responseDto.Result = new List<StudentResponseIdPairDto>();
            foreach (var studentDto in studentsDto)
            {
                if (_context.Students.Any(x => x.ExternalId == studentDto._id))
                {
                    responseDto.Failed++;
                    continue;
                }
                var student = new Student()
                {
                    About = studentDto.about,
                    Name = studentDto.name.Split(' ')[0],
                    Surname = studentDto.name.Split(" ")[1],
                    Email = studentDto.email,
                    ExternalId = studentDto._id
                };
                responseDto.Success++;

                _context.Students.Add(student);
                _context.SaveChanges();

                responseDto.Result.Add(new StudentResponseIdPairDto()
                {
                    InternalId = student.Id,
                    ExternalId = studentDto._id
                }
                );
            }

            return responseDto;

        }

        public List<Student> GetList()
        {
            var result = _context.Students.ToList();
            return result;
        }
    }
}

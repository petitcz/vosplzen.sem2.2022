using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Migrations;
using vosplzen.sem2h1.Services.Interfaces;

namespace vosplzen.sem2h1.Services
{

    public class MasterSeedService:IMasterSeedService
    {
        internal ApplicationDbContext _context;

        public MasterSeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitSeed()
        {
            if (!_context.Students.Any())
            {
                _context.Students.Add(new Data.Model.Student()
                {
                    Email = "student@vosplzen.cz",
                    Name = "Test Data",
                    Surname = "Student Test",
                    About = "Test Data Student Table",
                    ExternalId = Guid.NewGuid().ToString()
                });


                _context.SaveChanges();

            }
        }

    }
}

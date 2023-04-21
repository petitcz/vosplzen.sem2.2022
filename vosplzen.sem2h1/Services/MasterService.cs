using vosplzen.sem2h1.Data;

namespace vosplzen.sem2h1.Services
{

    public class MasterService
    {
        internal ApplicationDbContext _context;
        public MasterService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}

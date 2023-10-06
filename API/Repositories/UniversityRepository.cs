using API.Contracts;
using API.Data;
using API.Models;


namespace API.Repositories
{
    //membuat university repo untuk jembatan menuju database dengan implemen contract interface
    public class UniversityRepository : GeneralRepository<University>, IUniversityRepository
    {
        private readonly BookingManagementDbContext _context;
        public UniversityRepository(BookingManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public University? GetUniversityNameByCode(string code)
        {
            return _context.Set<University>().FirstOrDefault(u => u.Code == code);
        }
    }
}


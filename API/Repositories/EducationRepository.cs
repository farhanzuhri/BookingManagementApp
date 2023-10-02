using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        //membuat context private dan readonly hanya untuk kelas ini
        private readonly BookingManagementDbContext _context;
        //melakukan dependency injection
        public EducationRepository(BookingManagementDbContext context)
        {
            _context = context;
        }
        //implementasi dbcontext getall
        public IEnumerable<Education> GetAll()
        {
            return _context.Set<Education>().ToList();
        }
        //implementasi dbcontext getbyGuid
        public Education? GetByGuid(Guid guid)
        {
            return _context.Set<Education>().Find(guid);
        }
        //implementasi dbcontext create
        public Education? Create(Education eduacation)
        {
            try
            {
                _context.Set<Education>().Add(eduacation);
                _context.SaveChanges();
                return eduacation;
            }
            catch
            {
                return null;
            }
        }
        //implementasi dbcontext Update
        public bool Update(Education eduacation)
        {
            try
            {
                _context.Set<Education>().Update(eduacation);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //implementasi dbcontext Delete
        public bool Delete(Education eduacation)
        {
            try
            {
                _context.Set<Education>().Remove(eduacation);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
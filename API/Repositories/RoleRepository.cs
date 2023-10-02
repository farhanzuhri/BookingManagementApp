using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        //membuat context private dan readonly hanya untuk kelas ini
        private readonly BookingManagementDbContext _context;
        //melakukan dependency injection
        public RoleRepository(BookingManagementDbContext context)
        {
            _context = context;
        }
        //implementasi dbcontext getall
        public IEnumerable<Role> GetAll()
        {
            return _context.Set<Role>().ToList();
        }
        //implementasi dbcontext getbyGuid
        public Role? GetByGuid(Guid guid)
        {
            return _context.Set<Role>().Find(guid);
        }
        //implementasi dbcontext create
        public Role? Create(Role role)
        {
            try
            {
                _context.Set<Role>().Add(role);
                _context.SaveChanges();
                return role;
            }
            catch
            {
                return null;
            }
        }
        //implementasi dbcontext Update
        public bool Update(Role role)
        {
            try
            {
                _context.Set<Role>().Update(role);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //implementasi dbcontext Delete
        public bool Delete(Role role)
        {
            try
            {
                _context.Set<Role>().Remove(role);
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
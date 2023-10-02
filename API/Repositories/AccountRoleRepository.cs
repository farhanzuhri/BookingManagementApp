using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class AccountRoleRepository : IAccountRoleRepository
    {
        //membuat context private dan readonly hanya untuk kelas ini
        private readonly BookingManagementDbContext _context;
        //melakukan dependency injection
        public AccountRoleRepository(BookingManagementDbContext context)
        {
            _context = context;
        }
        //implementasi dbcontext getall
        public IEnumerable<AccountRole> GetAll()
        {
            return _context.Set<AccountRole>().ToList();
        }
        //implementasi dbcontext getbyGuid
        public AccountRole? GetByGuid(Guid guid)
        {
            return _context.Set<AccountRole>().Find(guid);
        }
        //implementasi dbcontext create
        public AccountRole? Create(AccountRole accountRole)
        {
            try
            {
                _context.Set<AccountRole>().Add(accountRole);
                _context.SaveChanges();
                return accountRole;
            }
            catch
            {
                return null;
            }
        }
        //implementasi dbcontext Update
        public bool Update(AccountRole accountRole)
        {
            try
            {
                _context.Set<AccountRole>().Update(accountRole);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //implementasi dbcontext Delete
        public bool Delete(AccountRole accountRole)
        {
            try
            {
                _context.Set<AccountRole>().Remove(accountRole);
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

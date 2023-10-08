using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class RoleRepository : GeneralRepository<Role>, IRoleRepository
    {
        private readonly BookingManagementDbContext _context;
        public RoleRepository(BookingManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public Guid? GetRoleGuid()
        {
            return _context.Set<Role>().FirstOrDefault(r => r.Name == "User")?.Guid;
        }
    }
}
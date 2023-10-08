using API.Data;
using API.Models;
using API.Contracts;
using Microsoft.EntityFrameworkCore;
using API.Controllers;

namespace API.Repositories
{
    public class AccountRepository : GeneralRepository<Account>, IAccountRepository
    {
        private readonly BookingManagementDbContext _context;
        public AccountRepository(BookingManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public BookingManagementDbContext GetContext()
        {
            return _context;
        }
    }
}

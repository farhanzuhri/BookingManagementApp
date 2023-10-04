using API.Data;
using API.Models;
using API.Contracts;

namespace API.Repositories
{
    public class AccountRepository : GeneralRepository<Account>, IAccountRepository
    {
        public AccountRepository(BookingManagementDbContext context) : base(context) { }

    }
}
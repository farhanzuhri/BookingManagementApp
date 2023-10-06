using API.Data;
using API.Models;
using API.Contracts;
using Microsoft.EntityFrameworkCore;
using API.Controllers;

namespace API.Repositories
{
    public class AccountRepository : GeneralRepository<Account>, IAccountRepository
    {
        public AccountRepository(BookingManagementDbContext context) : base(context) { }

    }
}

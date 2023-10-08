using API.Data;
using API.Models;

namespace API.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account>
    {
        BookingManagementDbContext GetContext();
    }
}

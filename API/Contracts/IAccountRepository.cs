using API.Models;

namespace API.Contracts
{
    public interface IAccountRepository
    {
        //membuat interface method getall
        IEnumerable<Account> GetAll();

        //membuat interface method getbyGuid
        Account? GetByGuid(Guid guid);

        //membuat interface method Create
        Account? Create(Account account);

        //membuat interface method Update
        bool Update(Account account);

        //membuat interface method Delete
        bool Delete(Account account);
    }
}

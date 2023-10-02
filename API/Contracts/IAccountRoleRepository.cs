using API.Models;

namespace API.Contracts
{
    public interface IAccountRoleRepository
    {
        //membuat interface method getall
        IEnumerable<AccountRole> GetAll();

        //membuat interface method getbyGuid
        AccountRole? GetByGuid(Guid guid);

        //membuat interface method Create
        AccountRole? Create(AccountRole accountRole);

        //membuat interface method Update
        bool Update(AccountRole accountRole);

        //membuat interface method Delete
        bool Delete(AccountRole accountRole);
    }
}

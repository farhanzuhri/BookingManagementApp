using API.Models;

namespace API.Contracts
{
    public interface IRoleRepository
    {
        //membuat interface method getall
        IEnumerable<Role> GetAll();

        //membuat interface method getbyGuid
        Role? GetByGuid(Guid guid);

        //membuat interface method Create
        Role? Create(Role role);

        //membuat interface method Update
        bool Update(Role role);

        //membuat interface method Delete
        bool Delete(Role role);
    }
}

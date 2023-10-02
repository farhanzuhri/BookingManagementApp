using API.Models;

namespace API.Contracts
{
    public interface IRoomRepository
    {
        //membuat interface method getall
        IEnumerable<Room> GetAll();

        //membuat interface method getbyGuid
        Room? GetByGuid(Guid guid);

        //membuat interface method Create
        Room? Create(Room room);

        //membuat interface method Update
        bool Update(Room room);

        //membuat interface method Delete
        bool Delete(Room room);
    }
}

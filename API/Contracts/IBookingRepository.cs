using API.Models;

namespace API.Contracts
{
    public interface IBookingRepository
    {
        //membuat interface method getall
        IEnumerable<Booking> GetAll();

        //membuat interface method getbyGuid
        Booking? GetByGuid(Guid guid);

        //membuat interface method Create
        Booking? Create(Booking booking);

        //membuat interface method Update
        bool Update(Booking booking);

        //membuat interface method Delete
        bool Delete(Booking booking);
    }
}

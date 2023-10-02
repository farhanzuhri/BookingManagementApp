using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        //membuat context private dan readonly hanya untuk kelas ini
        private readonly BookingManagementDbContext _context;
        //melakukan dependency injection
        public RoomRepository(BookingManagementDbContext context)
        {
            _context = context;
        }
        //implementasi dbcontext getall
        public IEnumerable<Room> GetAll()
        {
            return _context.Set<Room>().ToList();
        }
        //implementasi dbcontext getbyGuid
        public Room? GetByGuid(Guid guid)
        {
            return _context.Set<Room>().Find(guid);
        }
        //implementasi dbcontext create
        public Room? Create(Room room)
        {
            try
            {
                _context.Set<Room>().Add(room);
                _context.SaveChanges();
                return room;
            }
            catch
            {
                return null;
            }
        }
        //implementasi dbcontext Update
        public bool Update(Room room)
        {
            try
            {
                _context.Set<Room>().Update(room);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //implementasi dbcontext Delete
        public bool Delete(Room room)
        {
            try
            {
                _context.Set<Room>().Remove(room);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

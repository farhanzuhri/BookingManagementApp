using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        //membuat context private dan readonly hanya untuk kelas ini
        private readonly BookingManagementDbContext _context;
        //melakukan dependency injection
        public BookingRepository(BookingManagementDbContext context)
        {
            _context = context;
        }
        //implementasi dbcontext getall
        public IEnumerable<Booking> GetAll()
        {
            return _context.Set<Booking>().ToList();
        }
        //implementasi dbcontext getbyGuid
        public Booking? GetByGuid(Guid guid)
        {
            return _context.Set<Booking>().Find(guid);
        }
        //implementasi dbcontext create
        public Booking? Create(Booking booking)
        {
            try
            {
                _context.Set<Booking>().Add(booking);
                _context.SaveChanges();
                return booking;
            }
            catch
            {
                return null;
            }
        }
        //implementasi dbcontext Update
        public bool Update(Booking booking)
        {
            try
            {
                _context.Set<Booking>().Update(booking);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //implementasi dbcontext Delete
        public bool Delete(Booking booking)
        {
            try
            {
                _context.Set<Booking>().Remove(booking);
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
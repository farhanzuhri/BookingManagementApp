using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //membuat context private dan readonly hanya untuk kelas ini
        private readonly BookingManagementDbContext _context;
        //melakukan dependency injection
        public EmployeeRepository(BookingManagementDbContext context)
        {
            _context = context;
        }
        //implementasi dbcontext getall
        public IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().ToList();
        }
        //implementasi dbcontext getbyGuid
        public Employee? GetByGuid(Guid guid)
        {
            return _context.Set<Employee>().Find(guid);
        }
        //implementasi dbcontext create
        public Employee? Create(Employee employee)
        {
            try
            {
                _context.Set<Employee>().Add(employee);
                _context.SaveChanges();
                return employee;
            }
            catch
            {
                return null;
            }
        }
        //implementasi dbcontext Update
        public bool Update(Employee employee)
        {
            try
            {
                _context.Set<Employee>().Update(employee);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //implementasi dbcontext Delete
        public bool Delete(Employee employee)
        {
            try
            {
                _context.Set<Employee>().Remove(employee);
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

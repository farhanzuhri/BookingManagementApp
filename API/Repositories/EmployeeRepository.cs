using API.Repositories;
using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        private readonly BookingManagementDbContext _context;
        public EmployeeRepository(BookingManagementDbContext context) : base(context)
        {
            _context = context;
        }
        public string? GetLastNik()
        {
            return _context.Set<Employee>().OrderByDescending(e => e.NIK).FirstOrDefault()?.NIK;
        }

        public Employee? GetByEmail(string email)
        {
            return _context.Set<Employee>().FirstOrDefault(e => e.Email == email);
        }

    }
}

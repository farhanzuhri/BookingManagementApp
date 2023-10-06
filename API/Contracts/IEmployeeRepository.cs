using API.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        public string? GetLastNik();
        public Employee? GetByEmail(string email);
    }
}

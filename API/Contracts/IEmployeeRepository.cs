using API.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository
    {
        //membuat interface method getall
        IEnumerable<Employee> GetAll();

        //membuat interface method getbyGuid
        Employee? GetByGuid(Guid guid);

        //membuat interface method Create
        Employee? Create(Employee employee);

        //membuat interface method Update
        bool Update(Employee employee);

        //membuat interface method Delete
        bool Delete(Employee employee);
    }
}

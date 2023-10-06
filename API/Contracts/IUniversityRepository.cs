using API.Models;

namespace API.Contracts
{
    public interface IUniversityRepository : IGeneralRepository<University>
    {
        public University? GetUniversityNameByCode(string code);
    }
}

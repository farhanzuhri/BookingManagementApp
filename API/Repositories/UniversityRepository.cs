using API.Contracts;
using API.Data;
using API.Models;


namespace API.Repositories
{
    //membuat university repo untuk jembatan menuju database dengan implemen contract interface
    public class UniversityRepository : GeneralRepository<University>, IUniversityRepository
    {
        public UniversityRepository(BookingManagementDbContext context) : base(context)
        {
        }
    }
}

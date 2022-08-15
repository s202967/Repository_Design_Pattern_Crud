using EmployeesWeb.Data;
using EmployeesWeb.Models;

namespace EmployeesWeb.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}

using EmployeesWeb.Data;
using EmployeesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesWeb.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<List<Employee>> GetAllEmployeeFromProcAsync(int id)
        {
            var res = await _db.employees
            .FromSqlRaw(String.Format($"EXECUTE spEmployee_GetAll {id}"))
            .ToListAsync();
            return res;
        }
    }
}

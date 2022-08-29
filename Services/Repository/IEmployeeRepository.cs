using EmployeesWeb.Models;

namespace EmployeesWeb.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<Employee>> GetAllEmployeeFromProcAsync(int id);

    }
}

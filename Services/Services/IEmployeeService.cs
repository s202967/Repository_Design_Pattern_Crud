using EmployeesWeb.Models;

namespace EmployeesWeb.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> FindByIdAsync(int id);
        Task<bool> CreateAsync(Employee employee);
        Task<bool> EditAsync(Employee employee);
        Task DeleteAsync(int id);





    }
}

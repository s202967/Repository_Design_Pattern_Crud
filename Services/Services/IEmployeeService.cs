using EmployeesWeb.Models;

namespace EmployeesWeb.Services
{
    public interface IEmployeeService
    {
        Task<Employee> FindByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task<bool> CreateAsync(Employee employee);
        Task<bool> EditAsync(Employee employee);
        Task<bool> DeleteAsync(int id);





    }
}

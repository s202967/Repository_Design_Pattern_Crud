using EmployeesWeb.Data;
using EmployeesWeb.Models;
using EmployeesWeb.Repository;
using EmployeesWeb.UOW;

namespace EmployeesWeb.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _uow;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork uow)
        {
            _employeeRepository = employeeRepository;
            _uow = uow;
        }


        public async Task<Employee> FindByIdAsync(int id)
        {
            //return await _employeeRepository.GetByIdAsync(id).ConfigureAwait(false); 
            var res = await _employeeRepository.GetAllEmployeeFromProcAsync(id).ConfigureAwait(false);
            return res.First();
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            //var resp = await _employeeRepository.GetAllAsync();
            var resp = await _employeeRepository.GetAllEmployeeFromProcAsync(-1).ConfigureAwait(false);
            return resp.ToList();

        }

        public async Task<bool> CreateAsync(Employee employee)

        {
            employee.CreatedBy = Guid.NewGuid();
            employee.CreatedOn = DateTime.Now;
            await _employeeRepository.AddAsync(employee);
            _uow.CommitChanges();
            //_employeeRepository.SaveChanges();
            return true;
        }

        public async Task<bool> EditAsync(Employee employee)
        {
            employee.ModifiedBy = Guid.NewGuid();
            employee.ModifiedOn = DateTime.Now;
            _employeeRepository.Update(employee);
            _uow.CommitChanges();
            //_employeeRepository.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await FindByIdAsync(id).ConfigureAwait(false);
            employee.DeletedBy = Guid.NewGuid();
            employee.DeletedOn = DateTime.Now;
            employee.IsDeleted = true;
            _employeeRepository.Update(employee);
            //_employeeRepository.Remove(res);
            _uow.CommitChanges();
            //_employeeRepository.SaveChanges(); 
            return true;
        }

        /*

                    public async Task<bool> EditAsync(Employee employee)
                    {
                        _employeeRepository.Update(employee);
                        return true;

                    }

                    public async Task<Employee> DetailsAsync(int? id)
                    {
                        return await _employeeRepository.GetByIdAsync(id.Value).ConfigureAwait(false);

                    }

                    public async Task<bool> DeleteAsync(int id)
                    {
                        var employee = await FindByIdAsync(id).ConfigureAwait(false);
                        _employeeRepository.Remove(employee);
                        return true;
                    }*/
    }


}

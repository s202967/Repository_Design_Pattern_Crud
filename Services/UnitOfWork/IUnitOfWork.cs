using EmployeesWeb.Models;
using EmployeesWeb.Repository;

namespace EmployeesWeb.UOW
{
    public interface IUnitOfWork : IDisposable
    {
         void CommitChanges();
    }
}

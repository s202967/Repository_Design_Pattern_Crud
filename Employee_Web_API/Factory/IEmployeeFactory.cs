using Employee_WebAPI.DTO;
using EmployeesWeb.Models;

namespace Employee_WebAPI.Factory
{
    public interface IEmployeeFactory
    {
         EmployeeDTO MapEmployeeEntityToDTO(Employee entity);

         Employee MapEmployeeDTOToEntity(EmployeeDTO dto);
    }
}


//EmployeeDTO MapEmployeeEntityToDTO(Employee entity);
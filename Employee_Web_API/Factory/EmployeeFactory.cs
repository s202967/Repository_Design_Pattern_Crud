using Employee_WebAPI.DTO;
using EmployeesWeb.Models;

namespace Employee_WebAPI.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee MapEmployeeDTOToEntity(EmployeeDTO dto)
        {
            Employee entity = new Employee();
            entity.EmployeeId = dto.EmployeeId;
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Position = dto.Position;
            entity.DateOfBirth = dto.DateOfBirth;
            return entity;
        }


        public EmployeeDTO MapEmployeeEntityToDTO(Employee entity)
        {
            EmployeeDTO dto = new();
            {
                dto.EmployeeId = entity.EmployeeId;
                dto.Name = entity.Name;
                dto.Email = entity.Email;
                dto.Position = entity.Position;
                dto.EmployeeId = entity.EmployeeId;
                dto.DateOfBirth = entity.DateOfBirth;
            }
            return dto;
        }







    }
}



//public List<EmployeeDTO> MapEmployeeEntityToDTO(List<Employee>? entity)
//{
//    if (entity == null)
//        return new List<EmployeeDTO>();
//    var result = entity.Select(x => new EmployeeDTO()
//    {
//        EmployeeId = x.EmployeeId,
//        Name = x.Name,
//        Email = x.Email,
//        Position = x.Position,
//    }).ToList();

//    return result;
//}
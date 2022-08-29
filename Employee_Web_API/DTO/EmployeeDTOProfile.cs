using AutoMapper;
using EmployeesWeb.Models;

namespace Employee_WebAPI.DTO
{
    public class EmployeeDTOProfile : Profile
    {
        public EmployeeDTOProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }

    }
}

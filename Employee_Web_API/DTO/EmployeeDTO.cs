using System.ComponentModel.DataAnnotations;

namespace Employee_WebAPI.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }

       // [DataType(DataType.Date)]
       // public DateTime? DateOfBirth { get; set; }
    }
}

using EmployeesWeb.Data;
using EmployeesWeb.Models;
using EmployeesWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Web_API.Controllers
{
    [Route("api/EmployeeAPI")]
    [ApiController]
    public class EmployeeAPIController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;

        public EmployeeAPIController(IEmployeeService employeeService, ApplicationDbContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var resp = await _employeeService.GetAllAsync().ConfigureAwait (false);
            return Ok(resp);
        }


        [HttpGet("id")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Employee>> FindByAsync(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var resp = await _employeeService.FindByIdAsync(id).ConfigureAwait(false);
            if(resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }



        
        
    }
}

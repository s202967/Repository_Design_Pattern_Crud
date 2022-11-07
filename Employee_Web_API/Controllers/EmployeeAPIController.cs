using Employee_WebAPI.DTO;
using Employee_WebAPI.Factory;
using EmployeesWeb.Data;
using EmployeesWeb.Models;
using EmployeesWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee_Web_API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeAPIController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeAPIController(IEmployeeService employeeService, IEmployeeFactory employeeFactory)
        {
            _employeeService = employeeService;
            _employeeFactory = employeeFactory;

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAll()
        {
            var resp = await _employeeService.GetAllAsync().ConfigureAwait(false);
            var empDTOs = resp.Select(x => _employeeFactory.MapEmployeeEntityToDTO(x)).ToList();
            //var data = await _employeeService.GetAllAsync().ConfigureAwait(false);
            //var dataDTO = _employeeFactory.MapEmployeeEntityToDTO(data);
            return Ok(empDTOs);
        }



        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> FindByAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var resp = await _employeeService.FindByIdAsync(id).ConfigureAwait(false);
            if (resp == null)
            {
                return NotFound();
            }
            var empDTOs = _employeeFactory.MapEmployeeEntityToDTO(resp);
          
            return Ok(empDTOs);
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> CreateAsync(EmployeeDTO empDTO)
        {
            var data = _employeeFactory.MapEmployeeDTOToEntity(empDTO);
            var res = await _employeeService.CreateAsync(data).ConfigureAwait(false);
            if (res)
                return Ok("Created Sucessfully");
            else return BadRequest();

            //var data = _employeeFactory.MapEmployeeDTOToEntity(dto);
            // await _employeeService.CreateAsync(employee);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> EditAsync(EmployeeDTO empDTO)
        {
            var data = _employeeFactory.MapEmployeeDTOToEntity(empDTO);
            var res = await _employeeService.EditAsync(data).ConfigureAwait(false);
            if (res)
                return Ok("Updated Successfully");
            else return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            await _employeeService.DeleteAsync(id).ConfigureAwait(false);
            return Ok("Deleted Successfully");
        }

    }
}

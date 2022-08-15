using EmployeesWeb.Data;
using EmployeesWeb.Models;
using EmployeesWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWeb.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IEmployeeService _service; // For DI use.
        public EmployeeController(IEmployeeService service)
        {
           // _db = db;
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
            //var res = _service.GetAllAsync();
            //return View(res);
            //IEnumerable<Employee> objCategoryList = _db.employees;
            //return View(objCategoryList);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(obj);
                return RedirectToAction("Index");
                //_db.employees.Add(obj);
                //_db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));

        }


        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeeFromDb = await _service.FindByIdAsync(id.Value).ConfigureAwait(false);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}
            //var employeeFromDb = _db.employees.Find(id); //find employee based on id
            
            //if (employeeFromDb == null)
            //{
            //    return NotFound();
            //}
            //return View(employeeFromDb);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int EmployeeId, Employee employee) 
        {
            await _service.EditAsync(employee);
            return RedirectToAction(nameof(Index));
            //if (ModelState.IsValid)
            //{
            //    _db.employees.Update(obj);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(obj);
            

        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFromDb = await _service.FindByIdAsync(id.Value).ConfigureAwait(false);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}
            //var employeeFromDb = _db.employees.Find(id); //find employee based on id

            //if (employeeFromDb == null)
            //{
            //    return NotFound();
            //}
            //return View(employeeFromDb);
        }


        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));

            //var obj = _db.employees.Find(id);
            //if(obj == null)
            //{ 
            //    return NotFound();
            //}
            
            //_db.employees.Remove(obj);
            //    _db.SaveChanges();
            //return RedirectToAction("Index");

        }
    }
}
